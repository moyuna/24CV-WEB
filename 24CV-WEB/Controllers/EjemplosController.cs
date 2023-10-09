using _24CV_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace _24CV_WEB.Controllers
{
    public class EjemplosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            Persona persona = new Persona();
            persona.Nombre = "Moisés";
            persona.Apellidos = "Torres";
            persona.FechaNacimiento = new DateTime(1992, 01, 15);

            return View(persona);
        }
    }
}
