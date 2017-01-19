using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    public class ApPair
    {
        public int predictedValue { get; set; }
        public int actualValue { get; set; }
    }

    public class AucCalculator
    {
        // From 'AUC Calculation Check' post in IJCNN Social Network Challenge forum
        // Credit: B Yang - original C++ code
        public static double Auc(List<ApPair> ap)
        {
            // AUC requires int array as dependent

            var all = ap.OrderBy(p => p.predictedValue)
                       .ToArray();

            long n = all.Length;
            long ones = all.Sum(v => v.actualValue);
            if (0 == ones || n == ones) return 1;

            long tp0, tn;
            long truePos = tp0 = ones; long accum = tn = 0; double threshold = all[0].predictedValue;
            for (int i = 0; i < n; i++)
            {
                if (all[i].predictedValue != threshold)
                { // threshold changes
                    threshold = all[i].predictedValue;
                    accum += tn * (truePos + tp0); //2* the area of  trapezoid
                    tp0 = truePos;
                    tn = 0;
                }
                tn += 1 - all[i].actualValue; // x-distance between adjacent points
                truePos -= all[i].actualValue;
            }
            accum += tn * (truePos + tp0); // 2 * the area of trapezoid
            return (double)accum / (2 * ones * (n - ones));
        }
    }
}
