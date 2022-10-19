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
    public class FileProductRepo : IProductRepo
    {
        public List<string> ReadAll()
        {
            List<string> prodList = new List<string>();
            string path = @"C:\Users\mike\Downloads\SampleData\Products.txt";
            string[] rows = File.ReadAllLines(path);
            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                prodList.Add(columns[0]);

            }
            return prodList;
        }

        public List<string> ReadByID(string productType)
        {
            List<string> prodData = new List<string>();
            string path = @"C:\Users\mike\Downloads\SampleData\Products.txt";
            string[] rows = File.ReadAllLines(path);
            string prodType;
            string CPSF;
            string LCPSF;
            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');
                
                if(columns[0] == productType)
                {
                    prodType = columns[0];
                    CPSF = columns[1];
                    LCPSF = columns[2];

                    prodData.Add(prodType);
                    prodData.Add(CPSF);
                    prodData.Add(LCPSF);

                    
                }
                
            }

            return prodData;

        }

        
    }
}
