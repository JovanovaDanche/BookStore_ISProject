using EBookStore.Domain.Integration;
using EBookStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Repository.Implementation
{
    public class HoneyRepository : IHoneyRepository
    {
        private readonly HoneyStoreDbContext _context;
        private DbSet<Products> entities;
        private DbSet<Orders> ordersEntities;
        string errorMessage = string.Empty;

        public HoneyRepository(HoneyStoreDbContext context)
        {
            _context = context;
            ordersEntities = context.Set<Orders>();
            entities = context.Set<Products>();
        }
    
        public List<Products> GetProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public int GetTotalOrders()
        {
            return ordersEntities.Count();
        }
    }
}
