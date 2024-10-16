using Microsoft.CodeAnalysis.Options;
using System.Drawing;

namespace ASM_ASPNETCORE.Models
{
    public class Product
    {
        public int ID_SANPHAM { get; set; }
        public string MA_SANPHAM { get; set; } = string.Empty;
        public string TEN_SANPHAM { get; set; } = string.Empty;
        public string HINH_SANPHAM { get; set; } = string.Empty;
        public int SOLUONG_SANPHAM { get; set; }
        public Decimal GIA_SANPHAM { get; set; }
        public string TINHTRANG_SANPHAM { get; set; } = string.Empty;
        public string MOTA_SANPHAM { get; set; } = string.Empty;
        public string MA_ADMIN { get; set; } = string.Empty;

    }
}
