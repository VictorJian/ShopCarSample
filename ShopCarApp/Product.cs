using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCarApp
{
    /*
         • 電子：ipad，iphone，螢幕，筆記型電腦，鍵盤   
         • 食品：麵包，餅乾，蛋糕，牛肉，魚，蔬菜   
         • 日用品：餐巾紙，收納箱，咖啡杯，雨傘   
         • 酒類：啤酒，白酒，伏特加 
        */
    public class Product
    {
        public int id { get; set; }

        /// <summary>
        /// 1: 電子; 2: 食品; 3: 日用品; 4: 酒類
        /// </summary>
        public int category { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 商品單價
        /// </summary>
        public double price { get; set; }
    }
}
