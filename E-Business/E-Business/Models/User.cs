using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Business.Models
{
    public class User
    {
        [Key]
        public string UID { get; set; }//用户ID
        public String UName { get; set; }//用户姓名
        public String UKey { get; set; }//用户密码  
        public bool USex { get; set; }//用户性别
        public String UImage { get; set; }//用户头像URL
        public double UCash { get; set; }//用户账户余额
        public String UEmail { get; set; }//用户Email
        public String UPhone { get; set; }//用户手机号码
        public String[] USurgRecord { get; set; }//用户浏览记录
        public String[] UCollect { get; set; }//用户收藏商品
        public String[] UShopCart { get; set; }//购物车
        public uint UCredit { get; set; }//用户积分
        public double UBail { get; set; }//用户保证金数量
        public String UAd { get; set; }
    }
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}