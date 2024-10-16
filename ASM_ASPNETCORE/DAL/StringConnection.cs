namespace ASM_ASPNETCORE.DAL
{
	public class StringConnection
	{
		protected readonly string connection;
		public StringConnection(IConfiguration configuration)
		{
			connection = configuration.GetConnectionString("DBConnect") ?? "";
		}
	}
}
