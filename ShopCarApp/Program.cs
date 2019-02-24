using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = Resources.GetProducts();

            #region 第一種狀況

            ShopCar shopCars1 = Resources.GetShopCarsBySituation(1);

            double shopCars1TotalPrice = Resources.CalculatePrice(ref shopCars1, ref products);

            #endregion


            #region 第二種狀況

            ShopCar shopCars2 = Resources.GetShopCarsBySituation(2);

            double shopCars2TotalPrice = Resources.CalculatePrice(ref shopCars2, ref products);

            #endregion

            Console.ReadLine();
        }
    }
}
