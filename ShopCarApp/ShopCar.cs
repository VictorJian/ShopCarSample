using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCarApp
{
    /// <summary>
    /// 購物車內每個商品
    /// </summary>
    public class ShopCarItem
    {
        public int id { get; set; }

        public int productId { get; set; }

        public int amount { get; set; }
    }

    /// <summary>
    /// 購物車
    /// </summary>
    public class ShopCar
    {
        /// <summary>
        /// 購物車的商品資料
        /// </summary>
        public List<ShopCarItem> shopCarItems { get; set; }

        /// <summary>
        /// 購物車下單時間
        /// </summary>
        public DateTime dateTime { get; set; }
    }

    /// <summary>
    /// 購物車與商品的關聯，主要取得每個商品的單價
    /// </summary>
    public class ShopCarItemProductMapping
    {
        /// <summary>
        /// 每個商品的類別 1: 電子; 2: 食品; 3: 日用品; 4: 酒類
        /// </summary>
        public int category { get; set; }

        /// <summary>
        /// 商品數量 * 單價
        /// </summary>
        public double totalPrice { get; set; }
    }
}
