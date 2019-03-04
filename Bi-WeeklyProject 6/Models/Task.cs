using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bi_WeeklyProject_6.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Task Title")]
        public string Tile { get; set; }      
        


    }
}