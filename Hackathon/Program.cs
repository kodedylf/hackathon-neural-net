using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvReader = new CsvReader(@"HACKATHON_2_CREDIT_MODEL_INPUTS.csv");
            var data = csvReader.ReadFile();
            Console.WriteLine("test");
        }


    }
}
