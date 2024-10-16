using ASM_ASPNETCORE.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ASM_ASPNETCORE.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly CartDAL _cartDAL;
		public ShoppingCartController(IConfiguration configuration)
		{
			_cartDAL = new CartDAL(configuration);
		}
		public IActionResult Index(string maNguoiDung)
		{
			var cartItem = _cartDAL.GetListCartByMaND(maNguoiDung);
			return View(cartItem);
		}
        [HttpPost]
        public IActionResult AddToCart(string maSanPham, int soLuong = 1) // Số lượng mặc định là 1
        {
            string maNguoiDung = "ND_0001"; // Lấy email người dùng từ session hoặc model

            // Thêm sản phẩm vào giỏ hàng
            _cartDAL.AddToCart(maSanPham, soLuong, maNguoiDung);

            // Chuyển hướng về trang giỏ hàng hoặc trang sản phẩm
            return RedirectToAction("Index", "Cart"); // Giả sử bạn có trang Index để hiển thị giỏ hàng
        }

    }
}
