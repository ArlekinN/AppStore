﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppStore.Models.Files;
using AppStore.Models;

namespace AppStore.BLL.Strategies
{
    internal class DataDisplayFiles: IDataDisplay
    {
        // все продукты 
        public override List<ShowProduct> ShowAllProducts()
        {
            List<ShowProduct> allProducts = new List<ShowProduct>();
            return allProducts;
        }
        // создать магазин
        public override bool CreateStore(string name, string address)
        {
            return true;
        }
        // создать продукт
        public override bool CreateProduct(string name)
        {
            return true;
        }
        // завести партию товаров в маг{азин
        public override bool DeliverGoodsToTheStore(string nameStore, List<dynamic> consigments)
        {
            return true;
        }
        // обновить цену партии товаров в магазине
        public override bool UpdatePriceOfGoodsInStore(string nameStore, List<dynamic> consigments)
        {
            return true;
        }
        // найти магазин магазин с самым дешевым товаром
        public override string SearchStoreCheapestProduct(string nameProduct)
        {
            return "";
        }
        // найти товары, которые можно купить на сумму sum
        public override List<dynamic> SearchProductOnTheSum(string nameStore, int sum)
        {
            List<dynamic> products = new List<dynamic>();
            return products;
        }
        //  Купить партию товаров 
        public override int BuyConsignmentInStore(string nameStore, List<dynamic> consigment)
        {
            return 0;
        }
        // найти магазин, в которым паратия товаров самая дешевая 
        public override string SearchStoreCheapestConsigment(List<dynamic> consigment)
        {
            return "";
        }
    }
}