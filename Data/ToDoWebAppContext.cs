using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data
{
    public class ToDoWebAppContext : DbContext
    {
        public ToDoWebAppContext (DbContextOptions<ToDoWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoWebApp.Models.ListItem> ListItem { get; set; } = default!;
    }
}
