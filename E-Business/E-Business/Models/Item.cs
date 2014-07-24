using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Business.Models
{
    public class Item
    {
        [Key]
        [Required]
        public int IID { get; set; }//商品ID
        [Required]
        public String IName{ get; set; }//商品名
        [Required]
        public String IImage{ get; set; }//商品图片的URL
        [Required]
        public double IPrice{ get; set; }//商品价格
        public String IDiscribe{ get; set; }//商品描述
        public double IComScore{ get; set; }//商品评分
        [Required]
        public uint ISelNum{ get; set; }//商品销售数量
        [Required]
        public int IShopID{ get; set; }//商品所属店铺ID
        [Required]
        public String IPlace{ get; set; }//商品所在地
        [Required]
        public uint ISurNum{ get; set; }//商品剩余数量
        [Required]
        public uint IURecNum{ get; set; }//商品尚未接收数量
        public Item(){}
    }
    public class ItemDBContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}