using EBookStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Web.Controllers
{
    public class HoneyProductsController : Controller
    {
        private readonly IHoneyService _honeyService;
        public HoneyProductsController(IHoneyService honeyService)
        {
            _honeyService = honeyService;
        }
        public IActionResult Index()
        {
            var products = _honeyService.GetAllProducts();
            var totalOrders = _honeyService.GetTotalOrders();
            //return View(_honeyService.GetAllProducts());
            ViewData["TotalOrders"] = totalOrders;
            return View(products);
        }
    }
}
