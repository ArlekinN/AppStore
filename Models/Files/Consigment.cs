using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models.Files
{
    internal class Consigment
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Consigment(string name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
}
