using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookStore.Domain.Integration;

namespace EBookStore.Repository.Interface
{
    public interface IHoneyRepository
    {
        List<Products> GetProducts();
        int GetTotalOrders();

    }
}
