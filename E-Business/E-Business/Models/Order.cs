using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Business.Models
{
    public class Order
    {
        [Key]
        public String OID{ get; set; }//订单号
        public String SID{ get; set; }//卖方ID
        public String BID{ get; set; }//买方ID
        public String IID{ get; set; }//商品ID
        public int Mailmanner{ get; set; }//邮寄方式
        public double MailPrice{ get; set; }//邮寄价格
        public double Discout{ get; set; }//积分折扣
        public double FPrice{ get; set; }//最终价格
        public String SAddress{ get; set; }//发货地址
        public String RAddress{ get; set; }//收货地址
        public String RecName{ get; set; }//收货人姓名
        public String RecPhone{ get; set; }//收货人手机
        public int State{ get; set; }//订单状态
    }
    public class OrderDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}