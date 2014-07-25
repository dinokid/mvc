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
        [Required]
        public int CID { get; set; }//评论ID
        [Required]
        public String CVID{ get; set; }//评价人ID
        [Required]
        public int CObjID{ get; set; }//评价商品ID
        [Required]
        public int CLevel{ get; set; }//评级
        public String CContent{ get; set; }//评价内容
        [Required]
        public DateTime CTime{ get; set; }//评价时间

        public Comment() {}
    }
    public class CommentDBContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
    }
}