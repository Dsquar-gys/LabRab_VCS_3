using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LabRab_3.Мягков
{
    public class Run
    {
        public List<Day> Days { get; set; }

        public decimal Sum { get; set; }

        public Run()
        {
            Days = new List<Day>();
            Sum = 0;
        }

        public void CreateDays()
        {
            Random random = new Random();
            DateTime today = DateTime.Now;
            DateTime temp = today;
            while (today.Day - 1 != temp.Day)
            {
                Days.Add(new Day(
                    temp.Day,
                    temp.ToString(),
                    random.Next(9, 10) / 15,
                    random.Next(1, 4) / 15,
                    random.Next(5, 9) / 15,
                    random.Next(9, 10) / 15,
                    random.Next(1, 4) / 15,
                    random.Next(30, 180)
                    ));
                temp = temp.AddDays(1);
            }
        }
        public void SaveDays()
        {

            StreamWriter writer = new StreamWriter("Data.json", false);

            writer.Write(JsonSerializer.Serialize<List<Day>>(Days));

            writer.Close();

        }

        public void GetDays()
        {
            StreamReader reader = new StreamReader("Data.json");

            string s = reader.ReadToEnd();

            if (s != "")
                Days = JsonSerializer.Deserialize<List<Day>>(s);

            reader.Close();
        }

        public void Print()
        {
            foreach (Day day in Days)
            {
                Console.WriteLine(day.Date);
            }
        }

        public void FindSum()
        {
            foreach (Day day in Days)
            {
                string s = DateTime.Parse(day.Date).ToString("ddd",
                        new CultureInfo("ru-Ru"));
                if (s == "Сб" || s == "Вс")
                {
                    Sum += day.Distance;
                }
            }

        }
    }

    public class Day
    {
        public Day(
            int number,
            string date,
            decimal maxSpeed,
            decimal minSpeed,
            decimal averageSpeed,
            decimal averagePulse,
            decimal distance,
            int minutes)
        {
            Number = number;
            Date = date;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
            AverageSpeed = averageSpeed;
            AveragePulse = averagePulse;
            Distance = distance;
            Minutes = minutes;
        }

        public int Number { get; set; }
        public string Date { get; set; }
        public decimal MaxSpeed { get; set; }
        public decimal MinSpeed { get; set; }
        public decimal AverageSpeed { get; set; }
        public decimal AveragePulse { get; set; }
        public decimal Distance { get; set; }
        public int Minutes { get; set; }

    }
}
