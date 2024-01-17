using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class DelPermisoRepository
    {
        private readonly string _connectionString;

        public DelPermisoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<string> jsonPermisos)
        {
            foreach (string value in jsonPermisos)
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_CHANGE_OPCIONESXGRUPO", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_GRUPO", value));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
