namespace P1_FloricelaArguedas_WebAppJHH.Models
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }

        public int IdCliente { get; set; }

        public DateOnly FechaEjecutado { get; set; }

        public DateOnly FechaAgendado { get; set; }

        public int m2Propiedad { get; set; }

        public int m2CercaViva { get; set; }

        public int DiasSinChapia { get; set; }

        public DateOnly FechaSiguienteChapia { get; set; }

        public string TipoZacate { get; set; }

        public bool ProductoAplicado { get; set; }

        public string TipoProductoAplicado { get; set; }

        public int CostoChapiaM2 { get; set; }

        public int CostoProductoM2 { get; set; }

        public string EstadoManteniemiento { get; set; }

        public int CostoLineal {  get; set; }
    }
}
