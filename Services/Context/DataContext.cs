using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using Microsoft.EntityFrameworkCore;

namespace lizg1.BlogBackEndL.Services.Context
{
    public class DataContext : DbContext
    {

        public DbSet<UserModel> UserInfo { get; set; }

        public DbSet<BlogItemModel> BlogInfo { get; set; }

        public DataContext(DbContextOptions options) : base(options) {
            
        }

        //function to create the tables themselves

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);        }

    }
}