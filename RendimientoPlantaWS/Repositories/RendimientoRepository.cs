using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class RendimientoRepository
    {
        private readonly string _connectionString;

        public RendimientoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<Rendimiento> jsonRendimientos)
        {
            foreach (Rendimiento value in jsonRendimientos)
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_MAN_RENDIMIENTO", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_ID", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_PlantaID", value.fincaId));
                        cmd.Parameters.Add(new SqlParameter("@P_LineaID", value.linea));
                        cmd.Parameters.Add(new SqlParameter("@P_RendimientoPorHora", value.rendimientoPorHora));
                        cmd.Parameters.Add(new SqlParameter("@P_FechaCreacion", value.fechaCreacion));
                        cmd.Parameters.Add(new SqlParameter("@P_UsuarioCreacion", value.usuarioCreacion));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
