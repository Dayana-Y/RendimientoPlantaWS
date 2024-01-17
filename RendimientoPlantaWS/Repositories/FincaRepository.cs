using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class FincaRepository
    {
        private readonly string _connectionString;

        public FincaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<Finca> jsonFincas)
        {
            foreach (Finca value in jsonFincas)
            {
                int estadoSQL = value.estado ? 1 : 0;
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_PLANTA", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_ID", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_nombre", value.nombre));
                        cmd.Parameters.Add(new SqlParameter("@P_abreviatura", value.abreviatura));
                        cmd.Parameters.Add(new SqlParameter("@P_estado", estadoSQL));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
