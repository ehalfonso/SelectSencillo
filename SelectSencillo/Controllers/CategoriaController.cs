using Microsoft.AspNetCore.Mvc;
using SelectSencillo.Datos.Contrato;
using SelectSencillo.Models;

namespace SelectSencillo.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IGenericDatos<Categoria> _categoria;
        public CategoriaController(IGenericDatos<Categoria> categoria)
        {
            _categoria = categoria;
        }
        public IActionResult Listar()
        {
            List<Categoria> lista = _categoria.GetList();
            return View(lista);
        }
    }
}
