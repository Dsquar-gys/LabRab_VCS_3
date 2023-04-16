using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRab_3.Мягков
{
    public class Run
    {
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
