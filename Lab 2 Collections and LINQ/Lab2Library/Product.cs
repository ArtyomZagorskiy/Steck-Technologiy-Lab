using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Library
{
    public class Product
    {
        public string Name { get; set; }    
        public string Description { get; set; } 
        public int countOfProductInStock { get; set; }

        public string ToString()
        {
            return $"Product with name: {this.Name}, description: {this.Description}, products in stock: {this.countOfProductInStock}";
        }
    }
}
