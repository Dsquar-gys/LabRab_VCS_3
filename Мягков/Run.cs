using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace LabRab_3
{
    public class Run
    {
        public List<Day> Days { get; set; }

        public decimal Sum { get; set; }

        public Run()
        {
            Days = new List<Day>();
            Sum = 0;
            
            GetDays();
            FindSum();
        }

        public void CreateDays()
        {
            Random random = new Random((int)(DateTime.Now.Ticks));
            DateTime today = DateTime.Now;
            DateTime temp = today;
            int minutes;
            decimal speed;
            while (today.Day - 1 != temp.Day)
            {
                minutes = random.Next(30, 180);
                speed = (Decimal)((random.Next(100, 200))) / 15;
                Days.Add(new Day(
                    temp.Day,
                    temp.ToString(),
                    (Decimal)((random.Next(200,300))) / 15,
                    (Decimal)((random.Next(50, 100))) / 15,
                    speed,
                    (random.Next(100, 400)),
                    minutes * speed + random.Next(100, 400) / 5,
                    minutes,
                    temp.ToString("ddd",
                        new CultureInfo("ru-Ru"))
                    ));
                temp = temp.AddDays(1);
            }
        }
        public void SaveDays()
        {
            CreateDays();
            using (FileStream fs = new FileStream("../Мягков/Data.json", FileMode.Truncate))
            {
                
                JsonSerializer.Serialize<List<Day>>(fs, Days);
                Console.WriteLine(JsonSerializer.Serialize<List<Day>>(Days));
            }

        }

        public void GetDays()
        {
            using (FileStream fs = new FileStream("../Мягков/Data.json", FileMode.Open))
            {
                Days = JsonSerializer.Deserialize<List<Day>>(fs);
            }
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
                
                if (day.DayOfWeek == "сб" || day.DayOfWeek == "вс")
                {
                    Sum += day.Distance;
                    Console.WriteLine(Sum);

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
            int minutes,
            string dayOfWeek)
        {
            Number = number;
            Date = date;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
            AverageSpeed = averageSpeed;
            AveragePulse = averagePulse;
            Distance = distance;
            Minutes = minutes;
            DayOfWeek = dayOfWeek;
        }
        public string DayOfWeek { get; set; }
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
