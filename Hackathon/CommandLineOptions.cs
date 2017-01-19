using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;

namespace Hackathon
{
    class CommandLineOptions
    {
        [Option("training", DefaultValue = false, HelpText = "Train the network")]
        public bool Training { get; set; }

        [Option('e', "epochs", DefaultValue = 1000, Required = false, HelpText = "Number of epochs to run the training.")]
        public int Epochs { get; set; }

        [Option('n', "networkfile", Required = true, HelpText = "Network file to either save to or load from.")]
        public string NetworkFile { get; set; }

        [Option('d', "data", Required = true, HelpText = "Dataset to use as input")]
        public string Dataset { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            // this without using CommandLine.Text
            //  or using HelpText.AutoBuild
            var usage = new StringBuilder();
            usage.AppendLine("Hackathon Neural Network Model 1.0");
            return usage.ToString();
        }
    }
}
