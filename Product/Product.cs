using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrarys
{
    public class Product
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        public Product(uint id, string name, double cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
