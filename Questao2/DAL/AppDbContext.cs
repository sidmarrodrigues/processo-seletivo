using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Questao2.Models;
using Questao2.Views.Home;

namespace Questao2.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbContext") { }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
    }
}