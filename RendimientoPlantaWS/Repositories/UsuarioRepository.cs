using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<Usuario> jsonUsuarios)
        {
            foreach (Usuario value in jsonUsuarios)
            {
                int estadoSQL = value.estado ? 1 : 0;
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_USER", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_ID", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_nombre", value.nombre));
                        cmd.Parameters.Add(new SqlParameter("@P_apellido", value.apellidos));
                        cmd.Parameters.Add(new SqlParameter("@P_email", value.email));
                        cmd.Parameters.Add(new SqlParameter("@P_contrasenna", value.contrasenna));
                        cmd.Parameters.Add(new SqlParameter("@P_estado", estadoSQL));
                        cmd.Parameters.Add(new SqlParameter("@P_fincaID", value.fincaId));
                        cmd.Parameters.Add(new SqlParameter("@P_rol", value.rol));
                        cmd.Parameters.Add(new SqlParameter("@P_lineaID", value.linea));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            }
    }
}
