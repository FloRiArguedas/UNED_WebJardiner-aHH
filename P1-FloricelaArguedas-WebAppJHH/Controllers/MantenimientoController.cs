using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class MantenimientoController : Controller
    {
        public static IList<Mantenimiento> listadeMantenimientos = new List<Mantenimiento>();

        // GET: MantenimientoController
        public ActionResult Index()
        {
            if (!listadeMantenimientos.Any())
            {
                ViewBag.Mensaje = "No hay Mantenimientos registrados disponibles. Por favor, crea uno nuevo.";
            }
            return View(listadeMantenimientos);
        }

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MantenimientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        //LOGICA PARA CAMPOS AUTOCALCULADOS PARA LOS ATRIBUTOS DEL OBJETO

        // Instancia del objeto Mantenimiento para poder usar sus atributos para calcular campos
        Mantenimiento mantenimiento = new Mantenimiento();

        //METODO PARA DIAS SIN CHAPIA
        public void DiasSinChapia(Mantenimiento MantenimientoNuevo) {
            DateOnly FechaActual = DateOnly.FromDateTime(DateTime.Now); //Obtengo la fecha actual en ejecución
            TimeSpan tiempotranscurrido = FechaActual.ToDateTime(TimeOnly.MinValue) - MantenimientoNuevo.FechaEjecutado; //Resta de las fechas
            MantenimientoNuevo.DiasSinChapia = (int)tiempotranscurrido.TotalDays; //Extraigo el total de días y lo paso a INT
        }

        //METODO PARA FECHA SIGUIENTE CHAPIA

        public void fechaSiguientehapia(IList<Cliente> ListaClientes, Mantenimiento MantenimientoNuevo) {
            Cliente ClienteMantenimiento = null;
            if (ListaClientes.Any())
            {
                ClienteMantenimiento = ListaClientes.FirstOrDefault(cliente => cliente.Id == MantenimientoNuevo.IdCliente);
            }
            //VERANO
            DateTime FechaActual = DateTime.Now;
            if (FechaActual.Month == 12 || FechaActual.Month <= 4)
            {
                if (ClienteMantenimiento.MantenimientoVerano == "Quincenal")
                {
                    MantenimientoNuevo.FechaSiguienteChapia = MantenimientoNuevo.FechaEjecutado.AddDays(15);
                }
                else
                {
                    MantenimientoNuevo.FechaSiguienteChapia= MantenimientoNuevo.FechaEjecutado.AddDays(30);
                }
            }
            else { //INVIERNO

                if (ClienteMantenimiento.MantenimientoInvierno == "Quincenal")
                {
                    MantenimientoNuevo.FechaSiguienteChapia = MantenimientoNuevo.FechaEjecutado.AddDays(15);
                }
                else
                {
                    MantenimientoNuevo.FechaSiguienteChapia = MantenimientoNuevo.FechaEjecutado.AddDays(30);
                }
            }
        }


        //METODO PARA COSTO TOTAL MANTENIMIENTO

        public void CostoTotal(Mantenimiento MantenimientoNuevo) {

            int CostoTotal = (((MantenimientoNuevo.m2Propiedad + MantenimientoNuevo.m2CercaViva)* MantenimientoNuevo.CostoChapiaM2) + 
                              ((MantenimientoNuevo.m2Propiedad + MantenimientoNuevo.m2CercaViva)* MantenimientoNuevo.CostoProductoM2));
            MantenimientoNuevo.CostoTotalMantenimiento = CostoTotal + (CostoTotal*0.13);
        }
            

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mantenimiento MantenimientoNuevo)
        {
            //OBTENGO LA LISTA DE CLIENTES Y EXTRAIGO EL QUE SE NECESITA
            IList<Cliente> ListaClientes = ClienteController.listadeClientes;

            try
            {
                if (MantenimientoNuevo == null)
                {
                    return View();
                }
                else
                {
                    //Llamo a las funciones para los campos AutoCalculados
                    DiasSinChapia(MantenimientoNuevo);
                    fechaSiguientehapia(ListaClientes, MantenimientoNuevo);
                    CostoTotal(MantenimientoNuevo);
                    listadeMantenimientos.Add(MantenimientoNuevo);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Edit/5
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

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MantenimientoController/Delete/5
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
