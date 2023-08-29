using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lizg1.BlogBackEndL.Services.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {
            
        }
        
    }
}