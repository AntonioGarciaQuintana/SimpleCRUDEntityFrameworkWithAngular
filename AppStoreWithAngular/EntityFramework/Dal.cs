using AppStoreWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppStoreWithAngular.EntityFramework
{
    public class Dal: DbContext
    {


        public Dal() : base("dbconnection") { }

        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("tbl_products");
            modelBuilder.Entity<Product>().HasKey(x => x.id);
        }
    }
}