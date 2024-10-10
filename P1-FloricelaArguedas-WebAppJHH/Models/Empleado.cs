namespace P1_FloricelaArguedas_WebAppJHH.Models
{
    public class Empleado
    {
        public int Cedula { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Lateralidad { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public int SalarioxHora { get; set; }
    }
}
