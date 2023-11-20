using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Engine
    {
		//fields
		private int horsePower;
		private double cubicCapacity;

		//constructors
		public Engine(int horsePower, double cubicCapacity)
		{
			this.horsePower = horsePower;
			this.cubicCapacity = cubicCapacity;
		}

		//properties
		public int HorsePower
		{
			get { return horsePower; }
			set { horsePower = value; }
		}
		public double CubicCapacity
		{
			get { return cubicCapacity; }
			set { cubicCapacity = value; }
		}


	}
}
