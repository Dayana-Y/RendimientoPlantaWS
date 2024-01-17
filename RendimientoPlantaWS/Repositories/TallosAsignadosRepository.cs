using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class TallosAsignadosRepository
    {
        private readonly string _connectionString;

        public TallosAsignadosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<TallosAsignados> jsonTallosAsignadoss)
        {
            foreach (TallosAsignados value in jsonTallosAsignadoss)
            {
                int estadoSQL = value.estado ? 1 : 0;
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_TALLOS_ASIGNADOS", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_ID", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_PlantaID", value.fincaId));
                        cmd.Parameters.Add(new SqlParameter("@P_LineaID", value.lineaId));
                        cmd.Parameters.Add(new SqlParameter("@P_OperarioID", value.operarioId));
                        cmd.Parameters.Add(new SqlParameter("@P_OperarioLineaID", value.operarioLineaId));
                        cmd.Parameters.Add(new SqlParameter("@P_Fecha", value.fecha));
                        cmd.Parameters.Add(new SqlParameter("@P_HoraInicio", value.horaInicio));
                        cmd.Parameters.Add(new SqlParameter("@P_HoraFin", value.horaFin));
                        cmd.Parameters.Add(new SqlParameter("@P_Tallos", value.tallos));
                        cmd.Parameters.Add(new SqlParameter("@P_Tipo", value.tipo));
                        cmd.Parameters.Add(new SqlParameter("@P_Estado", value.estado));
                        cmd.Parameters.Add(new SqlParameter("@P_FechaCreacion", value.fechaCreacion));
                        cmd.Parameters.Add(new SqlParameter("@P_UsuarioCreacion", value.user));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
