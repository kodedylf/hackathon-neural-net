using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    public class DataHelper
    {
        public static string GetString(string[][] data, string column, int row)
        {
            var columnNumber = Array.IndexOf(data[0], column);
            return data[row][columnNumber];
        }

        public static double[][] CreateInputs(string[][] data)
        {
            var random = new Random();
            List<double[]> result = new List<double[]>();
            for (int i = 1; i < data.Length; i++)
            {
                double expected = GetString(data, "FINANCIAL_DISTRESS", i) == "YES" ? 1.0 : 0.0;
                result.Add(new double[] { expected, random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble(), random.NextDouble() });
            }
            return result.ToArray();
        }

        public static double[][] CreateOutputs(string[][] data)
        {
            List<double[]> result = new List<double[]>();
            for (int i = 1; i < data.Length; i++)
            {
                double expected = GetString(data, "FINANCIAL_DISTRESS", i) == "YES" ? 1.0 : 0.0;
                result.Add(new double[] { expected });
            }
            return result.ToArray();
        }
    }
}
