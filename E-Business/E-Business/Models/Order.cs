using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Business.Models
{
    public enum OrderState
    { 
        未发货,
        已发货未确认,
        确认付款,
        退货中,
    }
    public enum MailManner
    { 
        EMS,
        顺丰快递,
        圆通快递,
        平邮
    }
    public class Order
    {
        
        [Key]
        [Required]
        public int OID{ get; set; }//订单号
        [Required]
        public String SID{ get; set; }//卖方ID
        [Required]
        public String BID{ get; set; }//买方ID
        [Required]
        public int IID{ get; set; }//商品ID
        [Required]
        public MailManner Mailmanner{ get; set; }//邮寄方式
        [Required]
        public double MailPrice{ get; set; }//邮寄价格
        [Required]
        public double Discout{ get; set; }//积分折扣
        [Required]
        public double FPrice{ get; set; }//最终价格
        [Required]
        public String SAddress{ get; set; }//发货地址
        [Required]
        public String SelName { get; set; }//发货人姓名
        [Required]
        public String SelPhone { get; set; }//发货人手机
        [Required]
        public String RAddress{ get; set; }//收货地址
        [Required]
        public String RecName{ get; set; }//收货人姓名
        [Required]
        public String RecPhone{ get; set; }//收货人手机
        [Required]
        public uint ItemNumber { get; set; }//商品数量
        [Required]
        public OrderState State{ get; set; }//订单状态
        public Order() { }
    }
    public class OrderDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}