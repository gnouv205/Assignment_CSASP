using ASM_ASPNETCORE.DAL;
using ASM_ASPNETCORE.Models;
using ASM_ASPNETCORE.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ASM_ASPNETCORE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductDAL _productDAL;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _productDAL = new ProductDAL(configuration);
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var products = _productDAL.GetList();
            return View(products);
        }
        #region CreateProduct
        #region CreateProduct
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile HINH_SANPHAM)
        {
            if (ModelState.IsValid)
            {
                if (HINH_SANPHAM != null && HINH_SANPHAM.Length > 0)
                {
                    // Đường dẫn thư mục để lưu file hình ảnh
                    var uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "LayoutElectronic");

                    // Tạo thư mục nếu nó chưa tồn tại
                    if (!Directory.Exists(uploadsDirectory))
                    {
                        Directory.CreateDirectory(uploadsDirectory);
                    }

                    // Lấy tên file và tạo đường dẫn
                    var fileName = Path.GetFileName(HINH_SANPHAM.FileName);
                    var filePath = Path.Combine(uploadsDirectory, fileName);

                    // Lưu file hình ảnh vào thư mục
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await HINH_SANPHAM.CopyToAsync(stream);
                    }

                    // Lưu đường dẫn của ảnh vào product
                    product.HINH_SANPHAM = "/LayoutElectronic/" + fileName;
                }

                // Thêm sản phẩm vào database
                _productDAL.ThemSanPham(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
        #endregion

        #endregion
        #region UpdateProduct
        [HttpGet]
        public IActionResult Edit(string maSP)
        {
            var product = _productDAL.GetProductByMaSP(maSP);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile HINH_SANPHAM)
        {
            if (ModelState.IsValid)
            {
                if (HINH_SANPHAM != null)
                {
                    var uploadsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "LayoutElectronic");

                    // Tạo thư mục nếu nó chưa tồn tại
                    if (!Directory.Exists(uploadsDirectory))
                    {
                        Directory.CreateDirectory(uploadsDirectory);
                    }

                    var fileName = Path.GetFileName(HINH_SANPHAM.FileName);
                    var filePath = Path.Combine(uploadsDirectory, fileName);

                    // Lưu file vào thư mục
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await HINH_SANPHAM.CopyToAsync(stream);
                    }

                    product.HINH_SANPHAM = "/LayoutElectronic/" + fileName; // Lưu đường dẫn của ảnh vào product
                }

                // Cập nhật sản phẩm vào database
                _productDAL.CapNhatSanPham(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
        #endregion
        #region DeleteProduct
        [HttpGet]
        public IActionResult Delete(string maSP)
        {
            var product = _productDAL.GetProductByMaSP(maSP);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(string maSP)
        {
            _productDAL.XoaSanPhamTheoMaSP(maSP);
            return RedirectToAction(nameof(Index));
        }
        #endregion
        










    }
}
