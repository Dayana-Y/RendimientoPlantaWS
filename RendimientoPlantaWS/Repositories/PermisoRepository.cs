using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class PermisoRepository
    {
        private readonly string _connectionString;

        public PermisoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<Permiso> jsonPermisos)
        {
            foreach (Permiso value in jsonPermisos)
            {
                string id = value.uid;
                foreach (string permiso in value.nombres)
                {
                    using (SqlConnection sql = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("PR_UPD_OPCIONESXGRUPO", sql))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@P_grupo", id));
                            cmd.Parameters.Add(new SqlParameter("@P_opcion", permiso));
                            await sql.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
        }
    }
}
