namespace Bi_WeeklyProject_6.Models
{
   
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Database : DbContext
    {

        public Database()
            : base("name=DatabaseContext")
        {
        }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}