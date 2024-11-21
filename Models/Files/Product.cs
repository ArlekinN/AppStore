﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models.Files
{
    internal class Product
    {
        public string Name { get; set; }
        public int IdStore { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Product(string name, int idStore, int price, int amount)
        {
            Name = name;
            IdStore = idStore;
            Price = price;
            Amount = amount;
        }

    }
}
