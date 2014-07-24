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
        [Required]
        public int UID { get; set; }//用户ID
        [Required]
        public String UName { get; set; }//用户姓名
        [Required]
        public String UKey { get; set; }//用户密码  
        [Required]
        public bool USex { get; set; }//用户性别
        public String UImage { get; set; }//用户头像URL
        [Required]
        public double UCash { get; set; }//用户账户余额
        public String UEmail { get; set; }//用户Email
        public String UPhone { get; set; }//用户手机号码
        public int[] USurfRecord { get; set; }//用户浏览记录
        public int[] UCollect { get; set; }//用户收藏商品
        public int[] UShopCart { get; set; }//购物车
        [Required]
        public uint UCredit { get; set; }//用户积分
        [Required]
        public double UBail { get; set; }//用户保证金数量
        public String UAd { get; set; }//用户地址
        public User()
        {
            UCollect = new int[5];
            UShopCart = null;
            USurfRecord = null;
        }
    }
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}