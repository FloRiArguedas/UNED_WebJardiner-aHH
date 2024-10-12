using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class MaquinariaController : Controller
    {
        public static IList<Maquinaria> listadeMaquinaria = new List<Maquinaria>();

        // GET: MaquinariaController
        public ActionResult Index()
        {
            if (!listadeMaquinaria.Any()) 
            {
                Maquinaria maquinaria = new Maquinaria
                {
                    Id = 1,
                    Descripcion = "Chapeadora",
                    Tipo="Corta Setos",
                    HorasUsoActual = 8,
                    HorasUsoMaximo = 1000,
                    HorasMantenimiento = 100
                };
                listadeMaquinaria.Add(maquinaria);
            }
            return View(listadeMaquinaria);
        }

        // GET: MaquinariaController/Details/5
        public ActionResult Details(int id)
        {
            if (listadeMaquinaria.Any()) {
                Maquinaria MaquinariaALeer = listadeMaquinaria.FirstOrDefault(maquinaria => maquinaria.Id == id);
                return View(MaquinariaALeer);

            }
            return View();
        }

        // GET: MaquinariaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaquinariaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaquinariaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MaquinariaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaquinariaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MaquinariaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
