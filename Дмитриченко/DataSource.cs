using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;

namespace LabRab_3.Дмитриченко
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

    public static class DataSource
    {
        static WorkBook bookExcel;
        static WorkSheet sheetExcel;

        public static void SetSource(string path, int sheetNum)
        {
            bookExcel = new WorkBook("D:\\SUAI 2 year\\ТП\\ВВП.xlsx");
            sheetExcel = bookExcel.WorkSheets.First();
        }

        public static List<GridSource> ExtractData()
        {
            List<GridSource> src = new List<GridSource>();
            var rows = sheetExcel.Rows;
            foreach (var row in rows.Skip(1))
            {
                string[] temp = row.Take(2).Select(x => x.Value.ToString()).ToArray();
                src.Add(new GridSource(temp[0],temp[1]));
            }

            return src;
        }
    }
}
