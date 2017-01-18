using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Hackathon
{
    public class CsvReader
    {
        private readonly string _fileName;
        public CsvReader(string fileName)
        {
            _fileName = fileName;
        }

        public string[][] ReadFile()
        {
            var result = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(_fileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    result.Add(parser.ReadFields());
                }
            }
            return result.ToArray();
        }
    }
}
