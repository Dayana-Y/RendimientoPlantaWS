using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class OperarioRepository
    {
        private readonly string _connectionString;

        public OperarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<Operario> jsonOperarios) 
        {
            foreach (Operario value in jsonOperarios)
            {
                int estadoSQL = value.estado ? 1 : 0;
                int ocupadoSQL = value.ocupado? 1 : 0;
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_MAN_OPERARIOS", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_uid", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_identificacion", value.identificacion));
                        cmd.Parameters.Add(new SqlParameter("@P_nombre", value.nombre));
                        cmd.Parameters.Add(new SqlParameter("@P_apellidos", value.apellidos));
                        cmd.Parameters.Add(new SqlParameter("@P_codigo", value.codigo));
                        cmd.Parameters.Add(new SqlParameter("@P_estado", estadoSQL));
                        cmd.Parameters.Add(new SqlParameter("@P_ocupado", ocupadoSQL));
                        cmd.Parameters.Add(new SqlParameter("@P_usuarioCreacion", value.usuarioCreacion));
                        cmd.Parameters.Add(new SqlParameter("@P_fechaCreacion", value.fechaCreacion));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
        public IEnumerable<Operario> GetOperarios()
        {
            List<Operario> listaOperarios = new List<Operario>();
            try
            {
                SqlConnection sql = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GET_EMPLEADOS", sql);
                sql.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Operario operario = new Operario();
                    operario.identificacion = dr["Identificacion"].ToString();
                    operario.nombre = dr["Nombre"].ToString();
                    operario.apellidos = dr["Apellidos"].ToString();
                    operario.codigo = Int32.Parse(dr["Codigo"].ToString());
                    operario.uid = Int32.Parse(dr["Codigo"].ToString());
                    operario.estado = (Int32.Parse(dr["Estado"].ToString()) ==0) ? false : true;
                    operario.usuarioCreacion = dr["UsuarioCreacion"].ToString();
                    operario.fechaCreacion = dr["FechaCreacion"].ToString();
                    listaOperarios.Add(operario);
                }
                dr.Close();
                return listaOperarios;
            }
            catch (Exception e)
            {
                return listaOperarios;
            }
        }
    }
}
