using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookStore.Domain.Integration;

namespace EBookStore.Repository
{
    public class HoneyStoreDbContext:DbContext
    {
        public HoneyStoreDbContext(DbContextOptions<HoneyStoreDbContext> options)
    : base(options)
        {
        }

        public virtual DbSet <Products> Products { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

    }
}
