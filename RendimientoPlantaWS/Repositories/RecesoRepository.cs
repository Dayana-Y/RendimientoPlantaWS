using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class RecesoRepository
    {
        private readonly string _connectionString;

        public RecesoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<Receso> jsonRecesos)
        {
            foreach (Receso value in jsonRecesos)
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_MAN_RECESOS", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_uid", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_fincaId", value.fincaId));
                        cmd.Parameters.Add(new SqlParameter("@P_lineaId", value.lineaId));
                        cmd.Parameters.Add(new SqlParameter("@P_fecha", value.fecha));
                        cmd.Parameters.Add(new SqlParameter("@P_horaInicio", value.horaInicio));
                        cmd.Parameters.Add(new SqlParameter("@P_horaFin", value.horaFin));
                        cmd.Parameters.Add(new SqlParameter("@P_motivo", value.motivo));
                        cmd.Parameters.Add(new SqlParameter("@P_fechaCreacion", value.fechaCreacion));
                        cmd.Parameters.Add(new SqlParameter("@P_user", value.user));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
