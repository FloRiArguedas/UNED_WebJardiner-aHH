namespace P1_FloricelaArguedas_WebAppJHH.Models
{
    public class Maquinaria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public string Tipo { get; set; }

        public TimeSpan HorasUsoActual { get; set; }

        public TimeSpan HorasUsoMaximo { get; set; }

        public TimeSpan HorasMantenimiento { get; set; }
    }
}
