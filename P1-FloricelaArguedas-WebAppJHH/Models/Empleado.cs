using System.ComponentModel.DataAnnotations;

namespace P1_FloricelaArguedas_WebAppJHH.Models
{
    public class Empleado
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El ID solo puede contener números.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }
        public string Lateralidad { get; set; }

        [Required(ErrorMessage = "Fecha de Ingreso es obligatoria.")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "El Salario es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El Salario solo puede contener números.")]
        public int SalarioxHora { get; set; }
    }
}
