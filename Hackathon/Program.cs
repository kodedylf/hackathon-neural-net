using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Neuro;
using Accord.Neuro.Learning;

namespace Hackathon
{
    class Program
    {
        static void Main(string[] args)
        {
            double cutoff = 0.5;

            var csvReader = new CsvReader(@"..\..\..\HACKATHON_2_CREDIT_MODEL_INPUTS_HOULDOUT.csv");
            // var csvReader = new CsvReader(@"..\..\..\HACKATHON_2_CREDIT_MODEL_INPUTS_TRAINING.csv");
            var data = csvReader.ReadFile();
            var inputs = DataHelper.CreateInputs(data);
            var outputs = DataHelper.CreateOutputs(data);
            double error = 0.0;

            ActivationNetwork network;
            if (args.Length == 0)
            {
                network = new ActivationNetwork(new SigmoidFunction(), inputs[0].Length, inputs[0].Length, outputs[0].Length);
                var teacher = new ParallelResilientBackpropagationLearning(network);
                teacher.Reset(0.1);
                for (int i = 0; i < 1000; i++)
                {
                    error = teacher.RunEpoch(inputs, outputs);
                }
                network.Save(String.Format(@"..\..\..\network.ai"));
            }
            else
            {
                network = (ActivationNetwork)Network.Load(args[0]);
            }

            int expectedNoGotNo = 0;
            int expectedNoGotYes = 0;
            int expectedYesGotYes = 0;
            int expectedYesGotNo = 0;

            List<AucCalculator.ApPair> ap = new List<AucCalculator.ApPair>();
            for (int i = 0; i < inputs.Length; i++)
            {
                var result = network.Compute(inputs[i]);
                string expected = DataHelper.GetString(data, "FINANCIAL_DISTRESS", i + 1);
                if (expected == "NO" && result[0] <= cutoff) expectedNoGotNo++;
                if (expected == "NO" && result[0] > cutoff) expectedNoGotYes++;
                if (expected == "YES" && result[0] <= cutoff) expectedYesGotNo++;
                if (expected == "YES" && result[0] > cutoff) expectedYesGotYes++;
                ap.Add(new AucCalculator.ApPair() { actualValue = result[0] < 0.5 ? 0 : 1, predictedValue = (expected == "NO" ? 0 : 1) });
            }

            Console.WriteLine("AUC: " + AucCalculator.Auc(ap));

            Console.WriteLine("Expected No. Got No..." + expectedNoGotNo);
            Console.WriteLine("Expected No. Got Yes.." + expectedNoGotYes);
            Console.WriteLine("Expected Yes. Got No.." + expectedYesGotNo);
            Console.WriteLine("Expected Yes. Got Yes." + expectedYesGotYes);
        }
    }
}
