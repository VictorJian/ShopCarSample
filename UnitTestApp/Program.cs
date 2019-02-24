using ShopCarApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = Resources.GetProducts();

            #region 第一種狀況測試

            ShopCar shopCars1 = Resources.GetShopCarsBySituation(1);
            double resultShopCar1FromOriginalProject = Resources.CalculatePrice(ref shopCars1, ref products);

            double resultShopCar1 = 3023.6;

            bool result1 = (resultShopCar1 == Math.Round(resultShopCar1FromOriginalProject, 2, MidpointRounding.AwayFromZero));

            Console.WriteLine(string.Format("第一種狀況測試結果: {0}", result1));

            #endregion

            #region 第二種狀況測試

            ShopCar shopCars2 = Resources.GetShopCarsBySituation(2);
            double resultShopCar2FromOriginalProject = Resources.CalculatePrice(ref shopCars2, ref products);

            double resultShopCar2 = 43.54;

            bool result2 = (resultShopCar2 == Math.Round(resultShopCar2FromOriginalProject, 2, MidpointRounding.AwayFromZero));

            Console.WriteLine(string.Format("第二種狀況測試結果: {0}", result2));

            #endregion

            //console 視窗不會關閉
            Console.ReadLine();
        }
    }
}
