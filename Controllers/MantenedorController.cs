using Microsoft.AspNetCore.Mvc;
using CrudCore.Datos;
using CrudCore.Models;

namespace CrudCore.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //La vista muestra una lista de contactos
            var oLista = contactoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Devuelve solo la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Metodo recibe un objeto y guarda en BD
            if(!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = contactoDatos.Guardar(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }


        public IActionResult Editar(int IdContacto)
        {
            //Devuelve solo la vista
            var oContacto = contactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = contactoDatos.Editar(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int IdContacto)
        {
            //Devuelve solo la vista
            var oContacto = contactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {

            var respuesta = contactoDatos.Eliminar(oContacto.IdContacto);
            if (respuesta)
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
