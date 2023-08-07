namespace SelectSencillo.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public Categoria refCategoria { get; set; }
        public string Telefono { get; set; }
    }
}
