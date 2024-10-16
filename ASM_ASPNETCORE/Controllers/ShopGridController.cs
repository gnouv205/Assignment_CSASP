using ASM_ASPNETCORE.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ASM_ASPNETCORE.Controllers
{
    public class ShopGridController : Controller
    {
        private ProductDAL _productDAL;
        public ShopGridController(IConfiguration configuration)
        {
            _productDAL = new ProductDAL(configuration);
        }
        public IActionResult ShopGrid()
        {
            var productGrid = _productDAL.GetProducts();
            return View(productGrid);
        }
    }
}
