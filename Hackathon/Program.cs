using System;
using System.Collections.Generic;
using Accord.Neuro;
using Accord.Neuro.Learning;

namespace Hackathon
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine(options.GetUsage());
            }
            else
            {
                var csvReader = new CsvReader(options.Dataset);
                var data = csvReader.ReadFile();
                var inputs = DataHelper.CreateInputs(data);
                var outputs = DataHelper.CreateOutputs(data);
                double error = 0.0;

                ActivationNetwork network;
                if (options.Training)
                {
                    network = new ActivationNetwork(new SigmoidFunction(), inputs[0].Length, 20, 5, outputs[0].Length);
                    var teacher = new ParallelResilientBackpropagationLearning(network);
                    teacher.Reset(0.1);
                    for (int i = 0; i < options.Epochs; i++)
                    {
                        error = teacher.RunEpoch(inputs, outputs);
                        if (i%100 == 0) Console.WriteLine("Error: " + error);
                    }
                    network.Save(options.NetworkFile);
                }
                else
                {
                    network = (ActivationNetwork) Network.Load(options.NetworkFile);
                }

                List<ApPair> ap = new List<ApPair>();
                for (int i = 0; i < inputs.Length; i++)
                {
                    var result = network.Compute(inputs[i]);
                    string expected = DataHelper.GetString(data, "FINANCIAL_DISTRESS", i + 1);
                    ap.Add(new ApPair() {actualValue = result[0] < 0.5 ? 0 : 1, predictedValue = (expected == "NO" ? 0 : 1)});
                }

                Console.WriteLine("AUC: " + AucCalculator.Auc(ap));
            }
        }
    }
}
