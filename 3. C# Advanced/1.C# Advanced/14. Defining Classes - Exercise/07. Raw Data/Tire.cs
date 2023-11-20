using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Tire
    {
        private int age;
        private double pressure;

        public Tire(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age { get { return this.age; } set { this.age = value; } }

        public double Pressure { get { return this.pressure; } set { this.pressure = value; } }
    }
}
