using ASM_ASPNETCORE.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ASM_ASPNETCORE.DAL
{
	public class CartDAL : StringConnection
	{
		public CartDAL(IConfiguration configuration) : base(configuration) { }
        public List<Cart> GetListCartByMaND(string maNguoiDung)
        {
            var cartList = new List<Cart>();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("SP_HienThiGioHang", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Gán giá trị mặc định cho mã người dùng
                    maNguoiDung = "ND_0001";
                    cmd.Parameters.AddWithValue("@MA_NGUOIDUNG", maNguoiDung);  // Thay đổi ở đây

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var gioHang = new Cart
                            {
                                Ma_SanPham = reader["MA_SANPHAM"].ToString() ?? "",
                                Ten_SanPham = reader["TEN_SANPHAM"].ToString() ?? "",
                                Gia_SanPham = Convert.ToSingle(reader["GIA_SANHAM"]),
                                SoLuong_SanPham = Convert.ToInt32(reader["SOLUONG_SANPHAM"]),
                                Hinh_SanPham = reader["HINH_SANPHAM"].ToString() ?? ""
                            };
                            cartList.Add(gioHang);
                        }
                    }
                }
            }
            return cartList;
        }
        public void AddToCart(string maSanPham, int soLuong, string maNguoiDung)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ThemGioHang", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MA_SANPHAM", maSanPham);
                    cmd.Parameters.AddWithValue("@SOLUONG_SANPHAM", soLuong);
                    maNguoiDung = "ND_0001";
                    cmd.Parameters.AddWithValue("@EMAIL_NGUOIDUNG", maNguoiDung);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Thực thi stored procedure
                }
            }
        }



    }
}
