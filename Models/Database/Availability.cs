using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models.Database
{
    internal class Availability
    {
        public int IdStore { get; set; }
        public int IdProduct { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }

}
