using SelectSencillo.Datos.Contrato;
using SelectSencillo.Models;
using System.Data.SqlClient;
using System.Data;

namespace SelectSencillo.Datos.Implementacion
{
    public class UsuarioDatos : IGenericDatos<Usuario>
    {
        private readonly string _cadenaSql = "";
        public UsuarioDatos(IConfiguration configuration)
        {
            _cadenaSql = configuration.GetConnectionString("cadenaSql");
        }
        public List<Usuario> GetList()
        {
            List<Usuario> lista= new List<Usuario>();
            using(var conexion= new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            refCategoria = new Categoria
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                NombreCategoria = dr["NombreCategoria"].ToString()
                            }
                           
                        });
                    }
                }
            }
            return lista;
        }

        public bool Guardar(Usuario model)
        {
            using(var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_GuardarUsuario", conexion);
                cmd.Parameters.AddWithValue("NombreUsuario", model.NombreUsuario);
                cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                cmd.Parameters.AddWithValue("IdCategoria", model.refCategoria.IdCategoria);
                cmd.CommandType= CommandType.StoredProcedure;
                int filaAfectada=cmd.ExecuteNonQuery();
                if(filaAfectada>0)
                {
                    return true;
                }
                else { 
                    return false; 
                }
            }

        }
    }
}
