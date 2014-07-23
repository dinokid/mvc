using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace E_Business.Models
{
    public class Comment
    {
        public String CID;//评价人ID
        public String CObjID;//评价商品ID
        public int CLevel;//评级
        public String CContent;//评价内容
        public int[] CTime;//评价时间
    }
    public class CommentDBContent : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
    }
}