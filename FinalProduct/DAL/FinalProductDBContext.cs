using FinalProduct.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Configuration;
using System.Runtime.Remoting.Contexts;
using System.Linq;
using System.Web;

namespace FinalProduct.DAL
{
    public class FinalProductDBContext : DbContext
    {
        public FinalProductDBContext()
         
            :base("name=FinalProductDBContext")

        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}