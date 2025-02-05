using EBookStore.Domain.Integration;
using EBookStore.Repository.Interface;
using EBookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Service.Implementation
{
    public class HoneyService : IHoneyService
    {
        private readonly IHoneyRepository _honeyRepository;
        public HoneyService(IHoneyRepository honeyRepository)
        {
            _honeyRepository = honeyRepository;
        }
        public List<Products> GetAllProducts()
        {
            return _honeyRepository.GetProducts();
        }

        public int GetTotalOrders()
        {
            return _honeyRepository.GetTotalOrders();
        }
    }
}
