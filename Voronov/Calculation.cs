using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LabRab_3.Voronov
{
    public class Calculation
    {
        public List<Day> Days { get; set; }

        public Calculation()
        {
            Days = new List<Day>();
            IndexDay = -1;
            MaxValue = Int32.MinValue;
        }

        public int IndexDay { get; set; }
        public int MaxValue { get; set; }
        public void GenerationData()
        {
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                Days.Add(new Day(i, random.Next(27, 33), random.Next(15, 22), random.Next(22, 27)));
            }
        }
        public void SaveList()
        {

            StreamWriter writer = new StreamWriter("../Voronov/data.json", false);

            writer.Write(JsonSerializer.Serialize<List<Day>>(Days));

            writer.Close();

        }

        public void GetList()
        {
            StreamReader reader = new StreamReader("../Voronov/data.json");

            string s = reader.ReadToEnd();
            if (s != "")
                Days = JsonSerializer.Deserialize<List<Day>>(s);
            reader.Close();
        }

        public void PrintToConsole()
        {
            foreach (Day data in Days)
            {
                Console.WriteLine($"{data.Number}: {data.Min}, {data.Average}, {data.Max}");
            }
        }

        public void FindMaxDay()
        {
            for (int i = 0; i < Days.Count; i++)
            {

                if (Days[i].Max - Days[i].Min > MaxValue)
                {
                    MaxValue = Days[i].Max - Days[i].Min;
                    IndexDay = i;
                }
            }

        }
    }


    public class Day
    {
        public Day(int number, int max, int min, int average)
        {
            Number = number;
            Max = max;
            Min = min;
            Average = average;
        }

        public int Number { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int Average { get; set; }

    }
}
