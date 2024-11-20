using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Library
{
    public class Car
    {
        public float maxSpeed { get; set; }
        public string color { get; set; }
        public string manufacturer { get; set; }
        public int countOfPassengers { get; set; }  

        public string ToString()
        {
            return $"Car with color: {this.color}, maxSpeed: {this.maxSpeed}, manufacturer: {this.manufacturer}, passengers: {this.countOfPassengers}";
        }
    }
}
