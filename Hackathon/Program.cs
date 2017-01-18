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
            var csvReader = new CsvReader(@"..\..\..\HACKATHON_2_CREDIT_MODEL_INPUTS_TRAINING.csv");
            var data = csvReader.ReadFile();
            var inputs = DataHelper.CreateInputs(data);
            var outputs = DataHelper.CreateOutputs(data);
            double error = 0.0;

            ActivationNetwork network = new ActivationNetwork(new SigmoidFunction(), 10, 10, 1);
            var teacher = new ParallelResilientBackpropagationLearning(network);
            teacher.Reset(0.1);
            for (int i = 0; i < 100; i++)
            {
                error = teacher.RunEpoch(inputs, outputs);
            }

            Console.WriteLine(error);
        }


    }
}
