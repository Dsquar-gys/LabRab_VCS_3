using System.Collections.Generic;
using System.Linq;
using IronXL;

namespace LabRab_3
{
    public class Data
    {
        static WorkBook workBook;
        static WorkSheet workSheet;

        public List<int> years { get; set; } = new List<int>();
        public List<float> data { get; set; } = new List<float>();
        public List<float> percentChanges { get; set; } = new List<float>();

        public Data()
        {
            Data.ReadExcel();
            this.SetData();
        }
        public static void ReadExcel()
        {
            workBook = new WorkBook("../Жуковский/Население.xlsx");
            workSheet = workBook.WorkSheets.First();
        }
        public void SetData()
        {
            foreach (var cell in workSheet["A2:A16"])
            {
                years.Add(int.Parse(cell.Text));

            }
            foreach (var cell in workSheet["B2:B16"])
            {
                data.Add(int.Parse(cell.Text));
            }
            for (int i = 1; i < data.Count; i++)
            {
                float percent = data[i]/100;
                percentChanges.Add((data[i] - data[i-1])/percent);
            }

        }
    }
    
}