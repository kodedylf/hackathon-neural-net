using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    public class DataHelper
    {
        public static int GetInt(string[][] data, string column, int row)
        {
            var columnNumber = Array.IndexOf(data[0], column);
            return string.IsNullOrEmpty(data[row][columnNumber]) ? 0 : int.Parse(data[row][columnNumber]);
        }

        public static double GetDouble(string[][] data, string column, int row)
        {
            var columnNumber = Array.IndexOf(data[0], column);
            return string.IsNullOrEmpty(data[row][columnNumber]) ? 0.0 : double.Parse(data[row][columnNumber], CultureInfo.InvariantCulture);
        }

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
                List<double> inputs = new List<double>();
                inputs.Add(GetString(data, "DATE", i).Contains("2007") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "DATE", i).Contains("2008") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "DATE", i).Contains("2009") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "DATE", i).Contains("2010") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "DATE", i).Contains("2011") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "DATE", i).Contains("2012") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "DATE", i).Contains("2013") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "DATE", i).Contains("2014") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "DATE", i).Contains("2015") ? 1.0 : 0.0);
                inputs.Add(GetString(data, "MARITAL_STATUS", i) == "SINGLE" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "MARITAL_STATUS", i) == "MARRIED" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "MARITAL_STATUS", i) == "COHABITANT" ? 1.0 : 0.0);
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "AGE_1", i)) / 100.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "AGE_2", i)) / 100.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "NUMBER_OF_CHILDREN", i)) / 5.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "CHILDREN_AGE_MIN", i)) / 20.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "CHILDREN_AGE_MAX", i)) / 20.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "INCOME_FAMILY_SUPPLEMENT", i)) / 10000.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "INCOME_FAMILY_SUPPLEMENT", i)) / 100000.0));
                inputs.Add(GetString(data, "MUNICIPALITY_TYPE", i) == "Middle" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "MUNICIPALITY_TYPE", i) == "Rural" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "MUNICIPALITY_TYPE", i) == "Urban" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "MUNICIPALITY_TYPE", i) == "Outskirt" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "SELECTED_PROPERTY_REGION", i) == "Region Hovedstaden" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "SELECTED_PROPERTY_REGION", i) == "Region Midtjylland" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "SELECTED_PROPERTY_REGION", i) == "Region Nordjylland" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "SELECTED_PROPERTY_REGION", i) == "Region Sjælland" ? 1.0 : 0.0);
                inputs.Add(GetString(data, "SELECTED_PROPERTY_REGION", i) == "Region Syddanmark" ? 1.0 : 0.0);
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "SELECTED_PROPERTY_PRICE", i)) / 5000000.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "DOWNPAYMENT", i)) / 1000000.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "EQUITY", i)) / 250000.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "LOANS_EXISTING_PRINCIPAL_AMOUNT", i)) / 3000000.0));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "LOANS_EXISTING_MAX_INTEREST_RATE", i)) / 20.0));
                inputs.Add(Math.Min(1.0, ((double)GetDouble(data, "LOAN_TO_VALUE", i)) / 100));
                inputs.Add(Math.Min(1.0, ((double)GetDouble(data, "DEBT_BANK_CURRENT", i)) / 300000));
                inputs.Add(Math.Min(1.0, ((double)GetDouble(data, "DEBT_OTHER_CURRENT", i)) / 300000));
                inputs.Add(Math.Min(1.0, ((double)GetDouble(data, "DEBT_CURRENT_REPAYMENT", i)) / 2000000));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "EXPENSES_FIXED_TOTAL", i)) / 30000));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "EXPENSES_FIXED_PROPERTY", i)) / 10000));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "EXPENSES_FIXED_NEW_LOANS", i)) / 20000));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "EXPENSES_INSURANCE_TOTAL", i)) / 5000));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "LOANS_NEW_MORTGAGE_PAYMENT_INTEREST", i)) / 20000));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "LOANS_NEW_MORTGAGE_PAYMENT_TOTAL", i)) / 25000));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "LOANS_NEW_TOPUP_PAYMENT_TOTAL", i)) / 500000));
                inputs.Add(Math.Min(1.0, ((double)GetInt(data, "LOANS_WITH_IO", i)) / 5));



                // calculated values
                inputs.Add(((double)GetDouble(data, "ASSET_TOTAL", i)) / 1000000);
                inputs.Add(((double)GetDouble(data, "DEBT_FACTOR", i)) / 7.0);
                inputs.Add(((double)GetDouble(data, "FCF", i)) / 30000.00);
                inputs.Add(((double)GetDouble(data, "FFCF", i)) / 30000.00);

                // calculated ratios
                inputs.Add(GetDouble(data, "INCOME_CONCENTRATION_HHI", i));
                inputs.Add(GetDouble(data, "ASSETS_LIQUID_TO_ASSETS_TOTAL", i));
                inputs.Add(GetDouble(data, "ASSETS_PROPERTY_TO_ASSETS_TOTAL", i));
                inputs.Add(GetDouble(data, "DEBT_TOTAL_TO_ASSETS_TOTAL", i) / 10000.0);
                inputs.Add(GetDouble(data, "DEBT_TOTAL_TO_NET_EQUITY", i));
                inputs.Add(GetDouble(data, "DEBT_OTHER_TO_DEBT_TOTAL", i));
                inputs.Add(GetDouble(data, "DEBT_OTHER_TO_INCOME_TOTAL", i) / 10000.0);
                inputs.Add(GetDouble(data, "FFCF_TO_ASSET_TOTAL", i) / 50000.0);
                inputs.Add(GetDouble(data, "FFCF_TO_DEBT_TOTAL", i) * 10.0);
                inputs.Add(GetDouble(data, "FFCF_TO_INCOME_TOTAL", i));
                inputs.Add(GetDouble(data, "EXPENSES_PROPERTY_TO_EXPENES_TOTAL", i));
                inputs.Add(GetDouble(data, "INCOME_CHILD_TO_INCOME_TOTAL", i));
                inputs.Add(GetDouble(data, "SALARY_TO_INCOME_TOTAL", i));
                inputs.Add(GetDouble(data, "EXPENSES_FIXED_TO_INCOME_TOTAL", i));
                inputs.Add(GetDouble(data, "EXPENSES_PROPERTY_TO_EXPENSES_FIXED", i));
                inputs.Add(GetDouble(data, "EXPENSES_LOAN_TO_EXPENSES_TOTAL", i));
                inputs.Add(GetDouble(data, "EXPENSES_LOAN_TO_INCOME_TOTAL", i));
                inputs.Add(GetDouble(data, "EXPENSES_PROPERTY_LOAN_TO_EXPENSES_TOTAL", i));
                inputs.Add(GetDouble(data, "EXPENSES_PROPERTY_LOAN_TO_INCOME_TOTAL", i));
                inputs.Add(GetDouble(data, "DEBT_MORTGAGE_TO_INCOME_TOTAL", i) / 100.0);
                inputs.Add(GetDouble(data, "DEBT_TOTAL_TO_INCOME_TOTAL", i) / 100.0);
                inputs.Add(GetDouble(data, "CHILDREN_TO_ADULTS", i) / 2.0);
                inputs.Add(GetDouble(data, "AGE_DIFF", i) / 20.0);


                result.Add(inputs.ToArray());
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
