using ASM_ASPNETCORE.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ASM_ASPNETCORE.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDAL _productDAL;
        public ProductController(IConfiguration configuration)
        {
            _productDAL = new ProductDAL(configuration);
        }
        public IActionResult Index()
        {
            var products = _productDAL.GetProducts();
            if(products == null || !products.Any())
            {
                Console.WriteLine("No products found");
            }
            var topProducts = products.Take(8).ToList();
            return View(topProducts);
        }

        public IActionResult Details(string maSP)
        {
            var product = _productDAL.GetProductByMaSP(maSP);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
