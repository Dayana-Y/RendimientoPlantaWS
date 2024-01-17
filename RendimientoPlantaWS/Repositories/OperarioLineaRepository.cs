using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class OperarioLineaRepository
    {
        private readonly string _connectionString;

        public OperarioLineaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<OperarioLinea> jsonOperarioLineas)
        {
            foreach (OperarioLinea value in jsonOperarioLineas)
            {
                int estadoSQL = value.activo ? 1 : 0;
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_MAN_OPERARIOS_EN_LINEA", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_id", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_plantaId", value.fincaId));
                        cmd.Parameters.Add(new SqlParameter("@P_lineaId", value.lineaId));
                        cmd.Parameters.Add(new SqlParameter("@P_fecha", value.fecha));
                        cmd.Parameters.Add(new SqlParameter("@P_horaInicio", value.horaInicio));
                        cmd.Parameters.Add(new SqlParameter("@P_horaFin", value.horaFin));
                        cmd.Parameters.Add(new SqlParameter("@P_operarioId", value.operarioId));
                        cmd.Parameters.Add(new SqlParameter("@P_activo", value.activo));
                        cmd.Parameters.Add(new SqlParameter("@P_fechaCreacion", value.fechaCreacion));
                        cmd.Parameters.Add(new SqlParameter("@P_usuarioCreacion", value.user));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
