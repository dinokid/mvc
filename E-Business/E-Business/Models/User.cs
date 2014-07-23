using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace E_Business.Models
{
    public class User
    {
        public string UID;//用户ID
        public String UName;//用户姓名
        public String UKey;//用户密码
        public bool USex;//用户性别
        public String UImage;//用户头像URL
        public double UCash;//用户账户余额
        public String UEmail;//用户Email
        public String UPhone;//用户手机号码
        public String[] USurgRecord;//用户浏览记录
        public String[] UCollect;//用户收藏商品
        public String[] UShopCart;//购物车
        public uint UCredit;//用户积分
        public double UBail;//用户保证金数量
        public String UAd;
    }
    public class UserDBContent : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}