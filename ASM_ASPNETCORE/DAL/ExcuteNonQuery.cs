
using Microsoft.Data.SqlClient;
using System.Data;

namespace ASM_ASPNETCORE.DAL
{
    public class ExcuteNonQuery : StringConnection
    {
        public ExcuteNonQuery(IConfiguration configuration) : base(configuration)
        {
        }
        private void ExecuteNonQuery(string proc, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(proc, conn))
            {
                conn.Open();
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
