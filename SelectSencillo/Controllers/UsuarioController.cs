using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectSencillo.Datos.Contrato;
using SelectSencillo.Models;

namespace SelectSencillo.Controllers
{
    public class UsuarioController : Controller
    {
        private IGenericDatos<Usuario> _usuario;
        private IGenericDatos<Categoria> _categoria;
        public UsuarioController(IGenericDatos<Usuario> usuario, IGenericDatos<Categoria> categoria)
        {
            _usuario = usuario;
            _categoria = categoria;

        }
        public IActionResult Listar()
        {
            List<Usuario> lista =_usuario.GetList();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            List<Categoria>lista =_categoria.GetList();
            List<SelectListItem> listaC = lista.ConvertAll(
                item => new SelectListItem()
                {
                    Text = item.NombreCategoria.ToString(),
                    Value = item.IdCategoria.ToString(),
                    Selected = false
                });
            ViewBag.Lista = listaC;
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Usuario model)
        {
            bool usuarioGuardado=_usuario.Guardar(model);
            if(usuarioGuardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
