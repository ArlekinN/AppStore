using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{
    internal class Consigment
    {
        public string Product { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Consigment(string product, int price, int amount)
        {
            Product = product;
            Price = price;
            Amount = amount;
        }
        public Consigment() { }
    }
}
