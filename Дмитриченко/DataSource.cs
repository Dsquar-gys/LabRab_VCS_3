using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;

namespace LabRab_3
{
    public class GridSource
    {
        public string Year { get; }
        public string GDP { get; }

        public GridSource(string year, string money)
        {
            this.Year = year;
            GDP = money;
        }
    }

    public class DataSource : ISerializable
    {
        static WorkBook bookExcel;
        static WorkSheet sheetExcel;

        public List<int> yearTable { get; set; } = new List<int>();
        public List<float> data { get; set; } = new List<float>();
        public List<float> valueChanges { get; set; } = new List<float>();

        public DataSource()
        {
            DataSource.SetSource();
            this.ExtractData();
        }

        public static void SetSource()
        {

            bookExcel = new WorkBook("../Дмитриченко/ВВП.xlsx");
            sheetExcel = bookExcel.WorkSheets.First();
        }

        public void ExtractData()
        {
            var rows = sheetExcel.Rows;
            foreach (var row in rows.Skip(1))
            {
                string[] temp = row.Take(2).Select(x => x.Value.ToString()).ToArray();
                yearTable.Add(int.Parse(temp[0]));
                data.Add(float.Parse(temp[1]));
            }
            valueChanges.Add(0);
            for (int i = 1; i < data.Count; i++)
                valueChanges.Add((data[i]-data[i-1])/data[i-1]*100);
        }
    }
}
