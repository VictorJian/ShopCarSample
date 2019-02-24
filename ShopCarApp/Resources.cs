using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCarApp
{
    public class Resources
    {
        public static List<Product> GetProducts()
        {
            using (StreamReader r = new StreamReader(@"C:\workspace\ShopCar\ShopCarApp\data.json"))
            {
                string json = r.ReadToEnd();
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

                return products;
            }
        }

        public static ShopCar GetShopCarsBySituation(int situation)
        {
            string path = string.Format(@"C:\workspace\ShopCar\ShopCarApp\shopCar{0}.json", situation);

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<ShopCarItem> shopCarItems = JsonConvert.DeserializeObject<List<ShopCarItem>>(json);

                ShopCar shopCar = new ShopCar()
                {
                    shopCarItems = shopCarItems,
                    dateTime = DateTime.Parse("2018-11-11")
                };

                return shopCar;
            }
        }

        public static double CalculatePrice(ref ShopCar shopCars, ref List<Product> products)
        {
            List<ShopCarItemProductMapping> shopCars1Join = (from sc in shopCars.shopCarItems
                                                             join p in products on sc.productId equals p.id
                                                             select new ShopCarItemProductMapping()
                                                             {
                                                                 category = p.category,
                                                                 totalPrice = p.price * sc.amount
                                                             }).ToList();

            //條件一: 2018.11.11 當天  電子類商品一律 7 折 
            if (DateTime.Parse("2018-11-11") == shopCars.dateTime)
            {
                shopCars1Join.Where(w => w.category == 1).Select(s =>
                {
                    return s.totalPrice = s.totalPrice * 0.7;
                }).ToList();
            }

            //條件二: 2018.11.01 ~ 2018.11.15 酒類商品一律 8 折
            if (shopCars.dateTime >= DateTime.Parse("2018-11-01") && shopCars.dateTime <= DateTime.Parse("2018-11-15"))
            {
                shopCars1Join.Where(w => w.category == 4).Select(s =>
                {
                    return s.totalPrice = s.totalPrice * 0.8;
                }).ToList();
            }

            double shopCars1TotalPrice = shopCars1Join.Select(s => s.totalPrice).Sum();

            //條件三: 使用優惠券滿 1000 折 200，2019.3.2 到期
            if (shopCars.dateTime < DateTime.Parse("2019-03-02") && shopCars1TotalPrice >= 1000)
            {
                shopCars1TotalPrice = shopCars1TotalPrice - 200;
            }

            return shopCars1TotalPrice;
        }
    }
}
