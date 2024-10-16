using ASM_ASPNETCORE.DAL;
using ASM_ASPNETCORE.DTO;
using ASM_ASPNETCORE.Models;
using ASM_ASPNETCORE.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ASM_ASPNETCORE.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("admin")]
	
	public class HomeAdminController : Controller
	{
		private AdminUserDAL _adminUserDAL;
		private readonly IConfiguration _configuration;
		public HomeAdminController(IConfiguration configuration)
		{
			_configuration = configuration;
			_adminUserDAL = new AdminUserDAL(_configuration);
		}

		[HttpGet("")]
		[HttpGet("login")]
		public IActionResult Index()
		{
			var login = Request.Cookies.Get<LoginDTO>("UserCredential");
			return DoLogin(login);
		}
		[HttpPost("")]
		[HttpPost("login")]
		public IActionResult Index(LoginDTO login)
		{
			return DoLogin(login);
		}

		private IActionResult DoLogin(LoginDTO? login)
		{
			if(login != null)
			{
				var result = _adminUserDAL.Authenticate(login.Email_Admin, login.Password);
				if(result != null)
				{
					// Check Remember for next time
					if(login.RememberMe)
					{
						// Add a cookie
						Response.Cookies.Append<LoginDTO>("UserCredential", login, new CookieOptions
						{
							Expires = DateTimeOffset.UtcNow.AddDays(7),
							HttpOnly = true,
							IsEssential = true
						});
					}
					HttpContext.Session.Set<AdminUser>("userInfo", result);
					return RedirectToAction("dashboard");
				}
				else
				{
					ViewData["Message"] = "Wrong username or password!";
				}
			}
			return View();
		}
		[HttpGet("dashboard")]
		public IActionResult Dashboard()
		{
			return View();
		}

	}
}
