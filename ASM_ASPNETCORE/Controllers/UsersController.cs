using ASM_ASPNETCORE.DAL;
using ASM_ASPNETCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASM_ASPNETCORE.Controllers
{
	public class UsersController : Controller
	{
		private readonly UserDAL _userDAL;
		public UsersController(IConfiguration configuration)
		{
			_userDAL = new UserDAL(configuration);
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		// Xử lý khi người dùng gửi form đăng nhập
		[HttpPost]
		public IActionResult Login(string email, string password)
		{
			// Kiểm tra xem tài khoản có tồn tại và mật khẩu đúng hay không
			if (_userDAL.CheckUser(email, password, out string? maNguoiDung))
			{
				// Nếu đăng nhập thành công, lưu thông tin vào session
				HttpContext.Session.SetString("UserEmail", email);
				HttpContext.Session.SetString("MA_NGUOIDUNG", maNguoiDung);
				HttpContext.Session.SetString("LoginTime", DateTime.Now.ToString());

				return RedirectToAction("Index", "Product"); 
			}

			// Nếu thông tin đăng nhập sai
			ViewBag.ErrorMessage = "Email hoặc mật khẩu không đúng.";
			return View();
		}

		// Hiển thị trang chủ sau khi đăng nhập
		public IActionResult Index()
		{
			// Kiểm tra session xem người dùng đã đăng nhập chưa
			if (HttpContext.Session.GetString("UserEmail") != null)
			{
				ViewBag.UserEmail = HttpContext.Session.GetString("UserEmail");
				ViewBag.LoginTime = HttpContext.Session.GetString("LoginTime");
				ViewBag.MaNguoiDung = HttpContext.Session.GetString("MA_NGUOIDUNG"); // Lấy mã người dùng từ session
				return View();
			}

			return RedirectToAction("Login"); // Nếu chưa đăng nhập, điều hướng về trang đăng nhập
		}

		// Xử lý đăng xuất
		public IActionResult Logout()
		{
			HttpContext.Session.Clear(); // Xóa toàn bộ session
			return RedirectToAction("Login");
		}

		// Hiển thị form đăng ký
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		// Xử lý khi người dùng gửi form đăng ký
		[HttpPost]
		public IActionResult Register(User user)
		{
			// Kiểm tra tính hợp lệ của dữ liệu
			if (ModelState.IsValid)
			{
				// Thêm người dùng mới với mã người dùng, email và mật khẩu
				_userDAL.AddUser(user.MA_NGUOIDUNG, user.EMAIL_NGUOIDUNG, user.MATKHAU_NGUOIDUNG);
				return RedirectToAction("Login"); // Điều hướng về trang đăng nhập sau khi đăng ký thành công
			}

			return View(user);
		}
	}
}
