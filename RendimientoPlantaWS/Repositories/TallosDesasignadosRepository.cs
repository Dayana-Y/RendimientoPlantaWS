using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class TallosDesasignadosRepository
    {
        private readonly string _connectionString;

        public TallosDesasignadosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<TallosDesasignados> jsonTallosDesasignadoss)
        {
            foreach (TallosDesasignados value in jsonTallosDesasignadoss)
            {
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_TALLOS_DESASIGNADOS", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_ID", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_PlantaID", value.fincaId));
                        cmd.Parameters.Add(new SqlParameter("@P_LineaID", value.lineaId));
                        cmd.Parameters.Add(new SqlParameter("@P_OperarioID", value.operarioId));
                        cmd.Parameters.Add(new SqlParameter("@P_TallosAsignados", value.tallosAsignados));
                        cmd.Parameters.Add(new SqlParameter("@P_TallosDesasignados", value.tallosDesasignados));
                        cmd.Parameters.Add(new SqlParameter("@P_Motivo", value.motivo));
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
