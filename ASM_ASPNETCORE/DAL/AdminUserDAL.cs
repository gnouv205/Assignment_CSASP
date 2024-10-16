using ASM_ASPNETCORE.DTO;
using ASM_ASPNETCORE.Models;
using Microsoft.Data.SqlClient;
using DbDataReaderMapper;
using System.Data;

namespace ASM_ASPNETCORE.DAL
{
	public class AdminUserDAL : StringConnection
	{
		public AdminUserDAL(IConfiguration configuration ) : base( configuration )
		{

		}
		//public List<AdminUser> GetList()
		//{
		//	var data = new List<AdminUser>();
		//	try
		//	{
		//		using (SqlConnection conn = new SqlConnection(connection))
		//		{
		//			conn.Open();
		//			string query = "Select * from AdminUsers Order By DisplayOrder";
		//			using (SqlCommand cmd = new SqlCommand(query, conn))
		//			{
		//				using (SqlDataReader reader = cmd.ExecuteReader())
		//				{
		//					while (reader.Read())
		//					{
		//						data.Add(new AdminUser
		//						{
		//							User_ID = Convert.ToInt32(reader["USE_ID"]),
		//							Email_Admin = reader["EMAIL"].ToString() ?? "",
		//							Password = reader["PASSWORD"].ToString() ?? ""
		//						});
		//					}
		//				}
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
  //              Console.WriteLine(ex.Message);
  //          }
		//	return data;
		//}

		public AdminUser? GetById(int id)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connection))
				{
					conn.Open();
					string query = "Select * from AdminUsers Where USE_ID = @USE_ID";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@USE_ID", id);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								return new AdminUser
								{
									User_ID = Convert.ToInt32(reader["USE_ID"]),
									Email_Admin = reader["EMAIL"].ToString() ?? "",
									Password = reader["PASSWORD"].ToString() ?? ""
								};
							}
						}
					}
				}
			}
			catch (Exception ex )
			{
				Console.WriteLine(ex.Message);
			}
			return null;
		}


		public bool Add(AdminUser user)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connection))
				{
					conn.Open();
					string query = @"Insert Into AdminUsers(USE_ID, EMAIL, PASSWORD)
										Values(@USE_ID, @EMAIL, @PASSWORD)";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@USE_ID", user.User_ID);
						cmd.Parameters.AddWithValue("@EMAIL", user.Email_Admin);
						cmd.Parameters.AddWithValue("@PASSWORD", user.Password);

						int numRowEffected = cmd.ExecuteNonQuery();
						return numRowEffected > 0;
					}
				}
			}
			catch (Exception ex )
			{
				Console.WriteLine(ex.Message);
			}
			return false;
		}
		public bool Update (AdminUser user)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection( connection))
				{
					conn.Open();
					string query = @"Update AdminUsers Set
											USE_ID = @USE_ID
											EMAIL = @EMAIL
											PASSWORD = @PASSWORD";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@USE_ID", user.User_ID);
						cmd.Parameters.AddWithValue("@EMAIL", user.Email_Admin);
						cmd.Parameters.AddWithValue("@PASSWORD", user.Password);

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

		public bool Delete (int id)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connection))
				{
					conn.Open();
					string query = "Delete From AdminUsers Where USE_ID = @USE_ID";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@USE_ID", id);

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

		public AdminUser? Authenticate(string email, string password)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connection))
				{
					conn.Open();

					string query = @"SELECT * FROM TAIKHOAN_ADMIN
									WHERE EMAIL_ADMIN = @EMAIL_ADMIN AND MATKHAU_ADMIN = @MATKHAU_ADMIN";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{

						cmd.Parameters.AddWithValue("@EMAIL_ADMIN", email);
						cmd.Parameters.AddWithValue("@MATKHAU_ADMIN", password);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								return reader.MapToObject<AdminUser>();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				
				Console.WriteLine(ex.Message);
			}
			return null;
		}




	}
}
