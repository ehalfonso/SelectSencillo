using SelectSencillo.Datos.Contrato;
using SelectSencillo.Models;
using System.Data.SqlClient;
using System.Data;

namespace SelectSencillo.Datos.Implementacion
{
    public class CategoriasDatos : IGenericDatos<Categoria>
    {
        private readonly string _cadenaSql = "";
        public CategoriasDatos(IConfiguration configuracion) 
        {
            _cadenaSql = configuracion.GetConnectionString("cadenaSql");
        }
        public List<Categoria> GetList()
        {
           List<Categoria>  lista = new List<Categoria>();
            using (var conexion = new SqlConnection(_cadenaSql))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCategoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr=cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria
                        {
                            IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                            NombreCategoria = dr["NombreCategoria"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public bool Guardar(Categoria model)
        {
            throw new NotImplementedException();
        }
    }
}
