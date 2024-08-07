using Microsoft.EntityFrameworkCore;
using SharedDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDAL.Data
{    
    public class ToDoItemContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoItemContext(DbContextOptions<ToDoItemContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection", b => b.MigrationsAssembly("ToDoItemService"));
            }
        }
    }

}
