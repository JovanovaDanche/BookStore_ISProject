using EBookStore.Domain.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Service.Interface
{
    public interface IHoneyService
    {
        List<Products> GetAllProducts();
        int GetTotalOrders();
    }
}
