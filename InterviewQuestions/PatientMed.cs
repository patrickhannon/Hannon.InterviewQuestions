using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class PatientMed
    {
        public PatientMed(string Name, int temperature)
        {
            
        }
        public Interval Interval { get; set; }
        public string Name { get; set; }
        private int Temperature { get; set; }

        public bool HasTemperature(int currentTemp)
        {
            if (currentTemp > Temperature) return true;
            return false;
        }
    }
    public enum Interval
    {
        Hourly = 1,
        TwiceDaily = 2,
        Daily = 3

    }
}

