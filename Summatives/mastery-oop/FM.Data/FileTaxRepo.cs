using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FM.Data.Interfaces;
using FM.Models;
using System.IO;

namespace FM.Data
{
    public class FileTaxRepo : ITaxRepo
    {
        public List<string> ReadAll()
        {
            List<string> stateList = new List<string>();
            string path = @"C:\Users\mike\Downloads\SampleData\Taxes.txt";
            string[] rows = File.ReadAllLines(path);

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                stateList.Add(columns[0]);

            }
            return stateList;
        }

        

        public List<string> ReadByID(string stateAbbr)
        {
            List<string> taxData = new List<string>();
            string path = @"C:\Users\mike\Downloads\SampleData\Taxes.txt";
            string[] rows = File.ReadAllLines(path);
            string abbr;
            string stateFull;
            string taxRate;
            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                if (columns[0] == stateAbbr)
                {
                    abbr = columns[0];
                    stateFull = columns[1];
                    taxRate = columns[2];

                    taxData.Add(abbr);
                    taxData.Add(stateFull);
                    taxData.Add(taxRate);


                }

            }

            return taxData;
        }
    }
}
