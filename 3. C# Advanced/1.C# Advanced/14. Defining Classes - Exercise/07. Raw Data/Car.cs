using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Car
    {
        //fields
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        //constructors
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires) 
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }


        //properties
        public string Model { get { return model; } set { model = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public Cargo Cargo { get { return this.cargo; } set { this.cargo = value; } }
        public Tire[] Tires { get { return tires; } set { tires = value; } }


        //methods
        
    }
}
