using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace szamoranoBlog.Models
{
    public class CommentViewModel
    {
        //Represents a post id
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorId { get; set; }
        [Required]
        [AllowHtml]
        public string Body { get; set; }
    }
}