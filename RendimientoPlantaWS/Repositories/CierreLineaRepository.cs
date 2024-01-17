﻿using Microsoft.Extensions.Configuration;
using RendimientoPlantaWS.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RendimientoPlantaWS.Repositories
{
    public class CierreLineaRepository
    {
        private readonly string _connectionString;

        public CierreLineaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task Insert(IEnumerable<CierreLinea> jsonCierreLinea)
        {
            foreach (CierreLinea value in jsonCierreLinea)
            {

                int cerradoSQL = value.cerrado ? 1 : 0;
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("PR_UPD_CIERRES_LINEA", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@P_ID", value.uid));
                        cmd.Parameters.Add(new SqlParameter("@P_fincaId", value.fincaId));
                        cmd.Parameters.Add(new SqlParameter("@P_lineaId", value.lineaId));
                        cmd.Parameters.Add(new SqlParameter("@P_fechaCierre", value.fechaCierre));
                        cmd.Parameters.Add(new SqlParameter("@P_horaInicio", value.horaInicio));
                        cmd.Parameters.Add(new SqlParameter("@P_horaFin", value.horaFin));
                        cmd.Parameters.Add(new SqlParameter("@P_tallosParciales", value.tallosParciales));
                        cmd.Parameters.Add(new SqlParameter("@P_tallosCompletos", value.tallosCompletados));
                        cmd.Parameters.Add(new SqlParameter("@P_minutosEfectivos", value.minutosEfectivos));
                        cmd.Parameters.Add(new SqlParameter("@P_tallosPorHora", value.tallosXhora));
                        cmd.Parameters.Add(new SqlParameter("@P_rendimientoPorHora", value.rendimientoXhora));
                        cmd.Parameters.Add(new SqlParameter("@P_fechaCreacion", value.fechaCreacion));
                        cmd.Parameters.Add(new SqlParameter("@P_usuarioCreacion", value.usuarioCreacion));
                        cmd.Parameters.Add(new SqlParameter("@P_usuarioCierre", value.usuarioCierre));
                        cmd.Parameters.Add(new SqlParameter("@P_cerrado", cerradoSQL));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
