using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bi_WeeklyProject_6.Models;

namespace Bi_WeeklyProject_6.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username Required !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required !")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role Required !")]
        public Roles Role { get; set; }


        public IEnumerable<Task> Tasks { get; set; }
    }

    public enum Roles
    {
        Analyst,
        Architect,
        Programmer,
        Tester,
        Manager
    }
}