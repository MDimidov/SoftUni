using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tire
    {
        //fields
        private int year;
        private double pressure;

        //constructors
        public Tire(int year, double pressure)
        {
            this.year = year;
            this.pressure = pressure;
        }

        //properties
        public int Year { get { return year; } set { this.year = value; } }
        public double Pressure { get { return pressure; } set { pressure = value; } }
    }
}
