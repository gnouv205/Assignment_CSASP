using ASM_ASPNETCORE.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASM_ASPNETCORE.DAL
{
	public class ProductDAL : StringConnection
	{
		public ProductDAL(IConfiguration configuration) : base(configuration) { }

		public List<Product> GetProducts()
		{
			var products = new List<Product>();
			using (SqlConnection conn = new SqlConnection(connection))
			{
				string query = @"SELECT 
									MA_SANPHAM, 
									TEN_SANPHAM, 
									HINH_SANPHAM,
									SOLUONG_SANPHAM, 
									GIA_SANPHAM, 
									TINHTRANG_SANPHAM, 
									MOTA_SANPHAM, 
									MA_ADMIN
								FROM SANPHAM";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					conn.Open();
					
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							products.Add(new Product
							{
								MA_SANPHAM = reader["MA_SANPHAM"].ToString() ?? "",
								TEN_SANPHAM = reader["TEN_SANPHAM"].ToString() ?? "",
								HINH_SANPHAM = reader["HINH_SANPHAM"].ToString() ?? "",
								SOLUONG_SANPHAM = (int)reader["SOLUONG_SANPHAM"],
								GIA_SANPHAM = Convert.ToDecimal(reader["GIA_SANPHAM"]), 
								TINHTRANG_SANPHAM = reader["TINHTRANG_SANPHAM"].ToString() ?? "",
								MOTA_SANPHAM = reader["MOTA_SANPHAM"].ToString() ?? "",
                                MA_ADMIN = reader["MA_ADMIN"].ToString() ?? ""
							});
						}
					}
				}
			}
			return products;
		}
		public List<Product> GetList()
		{
			var data = new List<Product>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connection))
				{
					conn.Open();
					string query = @"Select * from SANPHAM order by MA_SANPHAM";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								data.Add( new Product{
									ID_SANPHAM = (int)reader["ID_SANPHAM"],
									MA_SANPHAM = reader["MA_SANPHAM"].ToString() ?? "",
									TEN_SANPHAM = reader["TEN_SANPHAM"].ToString() ?? "",
									HINH_SANPHAM = reader["HINH_SANPHAM"].ToString() ?? "",
									SOLUONG_SANPHAM = (int)reader["SOLUONG_SANPHAM"],
									GIA_SANPHAM = Convert.ToDecimal(reader["GIA_SANPHAM"]),
									TINHTRANG_SANPHAM = reader["TINHTRANG_SANPHAM"].ToString() ?? "",
									MOTA_SANPHAM = reader["MOTA_SANPHAM"].ToString() ?? "",
									MA_ADMIN = reader["MA_ADMIN"].ToString() ?? ""
								});
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return data;
		}
		public bool ThemSanPham(Product product)
		{
			try 
			{ 
				using (SqlConnection conn = new SqlConnection(connection))
				{
					conn.Open();
					string query = @"INSERT INTO SANPHAM (MA_SANPHAM, TEN_SANPHAM, HINH_SANPHAM, SOLUONG_SANPHAM, GIA_SANPHAM, TINHTRANG_SANPHAM, MOTA_SANPHAM, MA_ADMIN)
										VALUES (@MA_SANPHAM, @TEN_SANPHAM, @HINH_SANPHAM, @SOLUONG_SANPHAM, @GIA_SANPHAM, @TINHTRANG_SANPHAM, @MOTA_SANPHAM, @MA_ADMIN)";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@MA_SANPHAM", product.MA_SANPHAM);
						cmd.Parameters.AddWithValue("@TEN_SANPHAM", product.TEN_SANPHAM);
						cmd.Parameters.AddWithValue("@HINH_SANPHAM", product.HINH_SANPHAM);
						cmd.Parameters.AddWithValue("@SOLUONG_SANPHAM", product.SOLUONG_SANPHAM);
						cmd.Parameters.AddWithValue("@GIA_SANPHAM", product.GIA_SANPHAM);
						cmd.Parameters.AddWithValue("@TINHTRANG_SANPHAM", product.TINHTRANG_SANPHAM);
						cmd.Parameters.AddWithValue("@MOTA_SANPHAM", product.MOTA_SANPHAM);
						cmd.Parameters.AddWithValue("@MA_ADMIN", product.MA_ADMIN);

						int numRowEffected = cmd.ExecuteNonQuery();
						return numRowEffected > 0;

                    }

                }
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return false;
		}
        public bool CapNhatSanPham(Product product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = @"UPDATE SANPHAM 
                             SET TEN_SANPHAM = @TEN_SANPHAM, 
                                 HINH_SANPHAM = @HINH_SANPHAM, 
                                 SOLUONG_SANPHAM = @SOLUONG_SANPHAM, 
                                 GIA_SANPHAM = @GIA_SANPHAM, 
                                 TINHTRANG_SANPHAM = @TINHTRANG_SANPHAM, 
                                 MOTA_SANPHAM = @MOTA_SANPHAM, 
                                 MA_ADMIN = @MA_ADMIN
                             WHERE MA_SANPHAM = @MA_SANPHAM";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TEN_SANPHAM", product.TEN_SANPHAM);
                        cmd.Parameters.AddWithValue("@HINH_SANPHAM", product.HINH_SANPHAM);
                        cmd.Parameters.AddWithValue("@SOLUONG_SANPHAM", product.SOLUONG_SANPHAM);
                        cmd.Parameters.AddWithValue("@GIA_SANPHAM", product.GIA_SANPHAM);
                        cmd.Parameters.AddWithValue("@TINHTRANG_SANPHAM", product.TINHTRANG_SANPHAM);
                        cmd.Parameters.AddWithValue("@MOTA_SANPHAM", product.MOTA_SANPHAM);
                        cmd.Parameters.AddWithValue("@MA_ADMIN", product.MA_ADMIN);
                        cmd.Parameters.AddWithValue("@MA_SANPHAM", product.MA_SANPHAM);

                        int numRowEffected = cmd.ExecuteNonQuery();
                        return numRowEffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool XoaSanPhamTheoMaSP(string maSP)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "DELETE FROM SANPHAM WHERE MA_SANPHAM = @MA_SANPHAM";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MA_SANPHAM", maSP);

                        int numRowEffected = cmd.ExecuteNonQuery();
                        return numRowEffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }



        public Product? GetProductByMaSP(string maSP)
		{
			Product? product = null;
			using (SqlConnection conn = new SqlConnection(connection))
			{
				string query = "SELECT * FROM SANPHAM WHERE MA_SANPHAM = @MA_SANPHAM";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					// Chỉ định kiểu dữ liệu cho tham số
					cmd.Parameters.Add("@MA_SANPHAM", SqlDbType.VarChar, 20).Value = maSP;

					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							product = new Product
							{
								ID_SANPHAM = (int)reader["ID_SANPHAM"],
								MA_SANPHAM = reader["MA_SANPHAM"].ToString() ?? "",
								TEN_SANPHAM = reader["TEN_SANPHAM"].ToString() ?? "",
								HINH_SANPHAM = reader["HINH_SANPHAM"].ToString() ?? "",
								SOLUONG_SANPHAM = (int)reader["SOLUONG_SANPHAM"],
								GIA_SANPHAM = Convert.ToDecimal(reader["GIA_SANPHAM"]),
								TINHTRANG_SANPHAM = reader["TINHTRANG_SANPHAM"].ToString() ?? "",
								MOTA_SANPHAM = reader["MOTA_SANPHAM"].ToString() ?? "",
                                MA_ADMIN = reader["MA_ADMIN"].ToString() ?? ""

							};
						}
					}
				}
			}
			return product;
		}




	}
}
