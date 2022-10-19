using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using estockmarket.Models;

namespace estockmarket.Data
{
    public class estockmarketContext : DbContext
    {
        public estockmarketContext (DbContextOptions<estockmarketContext> options)
            : base(options)
        {
        }

        public DbSet<estockmarket.Models.Company> Company { get; set; }
    }
}
