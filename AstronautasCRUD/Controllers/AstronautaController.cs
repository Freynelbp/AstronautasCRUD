using AstronautasCRUD.Models;
using AstronautasCRUD.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.Routing;
using System.Web;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AstronautasCRUD.Controllers
{
    public class AstronautaController : Controller
    {
        AstronautaDatos _AstronautaDatos = new AstronautaDatos();
        
        //Controlador para Mostrar los Astronautas
        //Obtiene los parametos del filtro por medio del html
        public IActionResult Listar(string nacionalidad, string activo)
        {
            List<AstronautaModel> obj_Lista;
            if (activo == "todos" && string.IsNullOrEmpty(nacionalidad))
            {
                obj_Lista = _AstronautaDatos.Listar();
            }
            else if (activo == "todos" && !string.IsNullOrEmpty(nacionalidad))
            {
                obj_Lista = _AstronautaDatos.ObtenerFiltrado_Nacionalidad(nacionalidad);
            }
            else if (!string.IsNullOrEmpty(activo) && !string.IsNullOrEmpty(nacionalidad))
            {
                obj_Lista = _AstronautaDatos.ObtenerFiltrado_Nacionalidad_Activo(nacionalidad, activo);
            }
            else if(!string.IsNullOrEmpty(activo) && string.IsNullOrEmpty(nacionalidad))
            {
                obj_Lista = _AstronautaDatos.ObtenerFiltrado_Activo(activo);
            }
            else
            {
                obj_Lista = _AstronautaDatos.Listar();
            }
            return View(obj_Lista);
        }



        //Devuelve la Vista de Crear
        public IActionResult Crear()
        {
            return View();
        }

        //Crea el Astronauta
        [HttpPost]
        public IActionResult Crear(AstronautaModel obj_Astronauta)
        {
            //Sirve para los mensaje de campos vacios que presenten
            if (!ModelState.IsValid)
                return View();

            var respuesta = _AstronautaDatos.Crear(obj_Astronauta);

            if (respuesta)
                return RedirectToAction("Listar");

            return View();
        }


        //Devuelve la Vista de Editar, buscando el Astronauta correspondiente
        public IActionResult Editar(int IdAstronauta)
        {
            var respuesta = _AstronautaDatos.Obtener(IdAstronauta);

            return View(respuesta);

        }


        //Edita los datos del Astronauta obtenido
        [HttpPost]
        public IActionResult Editar(AstronautaModel obj_Astronauta)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _AstronautaDatos.Editar(obj_Astronauta);

            if (respuesta)
                return RedirectToAction("Listar");

            return View();

        }



        //Devuelve la Vista de Eliminar, Buscando el Astronauta correspondiente
        public IActionResult Eliminar(int IdAstronauta)
        {
            var respuesta = _AstronautaDatos.Obtener(IdAstronauta);

            return View(respuesta);

        }



        //Elimina el Astronauta que especificamos
        [HttpPost]
        public IActionResult Eliminar(AstronautaModel obj_Astronauta)
        {
            var respuesta = _AstronautaDatos.Eliminar(obj_Astronauta.IdAstronauta);

            if (respuesta)
                return RedirectToAction("Listar");

            return View();
        }



        //Este Controlador devuelve el "Conocer Mas" del Astronauta especificado
        public IActionResult Detalles(int IdAstronauta)
        {
            var respuesta = _AstronautaDatos.Obtener(IdAstronauta);

            return View(respuesta);

        }




    }
}
