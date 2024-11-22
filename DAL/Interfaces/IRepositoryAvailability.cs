﻿using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.DAL.Interfaces
{
    internal abstract class IRepositoryAvailability
    {
        public abstract Task<List<ShowProduct>> GetAllProducts();

        public Task<bool> DeliverGoodsToTheStore() { return Task.FromResult(true); }


    }
}
