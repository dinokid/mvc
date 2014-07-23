using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace E_Business.Models
{
    public class Order
    {
        public String OID;//订单号
        public String SID;//卖方ID
        public String BID;//买方ID
        public String IID;//商品ID
        public int Mailmanner;//邮寄方式
        public double MailPrice;//邮寄价格
        public double Discout;//积分折扣
        public double FPrice;//最终价格
        public String SAddress;//发货地址
        public String RAddress;//收货地址
        public String RecName;//收货人姓名
        public String RecPhone;//收货人手机
        public int State;//订单状态
    }
    public class OrderDBContent : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}