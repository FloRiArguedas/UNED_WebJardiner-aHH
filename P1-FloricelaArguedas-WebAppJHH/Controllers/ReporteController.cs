using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1_FloricelaArguedas_WebAppJHH.Services;
using P1_FloricelaArguedas_WebAppJHH.Models;

namespace P1_FloricelaArguedas_WebAppJHH.Controllers
{
    public class ReporteController : Controller
    {
        //Variable Global para la interfaz de Servicio
        private readonly IServicioCliente _iservicioCliente;

        //Constructor para instanciar la variable Global
        public ReporteController(IServicioCliente iservicioCliente)
        {
            _iservicioCliente = iservicioCliente;

        }


        // GET: ReporteController
        public async Task<ActionResult> Index()
        {
            List<Cliente> listadeClientes;
            listadeClientes = await _iservicioCliente.GetReportWeek();
            return View(listadeClientes);
        }


        // GET: ReporteMesController
        public async Task<ActionResult> IndexMes()
        {
            List<Cliente> listadeClientes;
            listadeClientes = await _iservicioCliente.GetReportMonth();
            return View(listadeClientes);
        }

    }
}
