using System.ComponentModel.DataAnnotations;

namespace ASM_ASPNETCORE.Models
{
    public class Cart
    {
        [Key]
        public int ID_GioHang { get; set; }

        [Required]
        [StringLength(20)]
        public string Ma_GioHang { get; set; } = string.Empty;

        [StringLength(20)]
        public string Ma_SanPham { get; set; } = string.Empty;

        [StringLength(100)]
        public string Ten_SanPham { get; set; } = string.Empty;

        [StringLength(100)]
        public string Hinh_SanPham { get; set; } = string.Empty;

        [StringLength(20)]
        public string Ma_NguoiDung { get; set; } = string.Empty;

        public float Gia_SanPham { get; set; }

        public int SoLuong_SanPham { get; set; }

        [StringLength(50)]
        public string TinhTrang_GioHang { get; set; } = string.Empty;

    }
}
