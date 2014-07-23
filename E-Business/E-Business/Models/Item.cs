using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace E_Business.Models
{
    public class Item
    {
        public String IID;//商品ID
        public String IName;//商品名
        public String IImage;//商品图片的URL
        public double IPrice;//商品价格
        public String IDiscribe;//商品描述
        public double IComScore;//商品评分
        public uint ISelNum;//商品销售数量
        public String IShopID;//商品所属店铺ID
        public String IPlace;//商品所在地
        public uint ISurNum;//商品剩余数量
        public uint IURecNum;//商品尚未接收数量
    }
    public class ItemDBContent : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}