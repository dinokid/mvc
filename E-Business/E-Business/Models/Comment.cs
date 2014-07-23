using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Business.Models
{
    public class Comment
    {
        [Key]
        public String CID{ get; set; }//评价人ID
        public String CObjID{ get; set; }//评价商品ID
        public int CLevel{ get; set; }//评级
        public String CContent{ get; set; }//评价内容
        public int[] CTime{ get; set; }//评价时间
    }
    public class CommentDBContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
    }
}