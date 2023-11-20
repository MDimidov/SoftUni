using System;
using System.Collections.Generic;
using System.Drawing;
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
        private int weight;
        private string color;

        //constructors

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }
        public Car(string model, Engine engine, int weight):this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color):this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }


        //properties
        public string Model { get { return model; } set { model = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public int Weight { 
            get 
            { 
                return weight; 
            }
            set { weight = value; } }
        public string Color { get { return this.color; } set { this.color = value; } }


        //methods
        
    }
}
