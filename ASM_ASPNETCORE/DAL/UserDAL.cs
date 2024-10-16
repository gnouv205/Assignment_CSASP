using Microsoft.Data.SqlClient;

namespace ASM_ASPNETCORE.DAL
{
	public class UserDAL : StringConnection
	{
		public UserDAL(IConfiguration configuration) : base(configuration) { }

		// Thêm người dùng mới vào cơ sở dữ liệu
		public void AddUser(string maNguoiDung, string email, string password)
		{
			using (SqlConnection conn = new SqlConnection(connection))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("INSERT INTO TAIKHOAN_NGUOIDUNG (MA_NGUOIDUNG, EMAIL_NGUOIDUNG, MATKHAU_NGUOIDUNG) VALUES (@MA_NGUOIDUNG, @EMAIL_NGUOIDUNG, @MATKHAU_NGUOIDUNG)", conn);
				cmd.Parameters.AddWithValue("@MA_NGUOIDUNG", maNguoiDung);
				cmd.Parameters.AddWithValue("@EMAIL_NGUOIDUNG", email);
				cmd.Parameters.AddWithValue("@MATKHAU_NGUOIDUNG", password);
				cmd.ExecuteNonQuery();
			}
		}



		// Kiểm tra thông tin đăng nhập
		public bool CheckUser(string email, string password, out string? maNguoiDung)
		{
			maNguoiDung = null;

			using (SqlConnection conn = new SqlConnection(connection))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("SELECT MA_NGUOIDUNG FROM Users WHERE EMAIL_NGUOIDUNG = @EMAIL_NGUOIDUNG AND MATKHAU_NGUOIDUNG = @MATKHAU_NGUOIDUNG", conn);
				cmd.Parameters.AddWithValue("@EMAIL_NGUOIDUNG", email);
				cmd.Parameters.AddWithValue("@MATKHAU_NGUOIDUNG", password);

				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					maNguoiDung = reader["MA_NGUOIDUNG"].ToString(); // Lấy giá trị MA_NGUOIDUNG nếu tồn tại
					return true;
				}
				return false;
			}
		}

	}
}

