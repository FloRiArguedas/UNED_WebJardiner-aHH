using System.ComponentModel.DataAnnotations;

namespace P1_FloricelaArguedas_WebAppJHH.Models
{
    public class Maquinaria
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El ID solo puede contener números.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descripción es obligatorio.")]
        public string Descripcion { get; set; }

        public string Tipo { get; set; }

        [Required(ErrorMessage = "Horas de Uso Actual es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El Campo solo puede contener números.")]
        public int HorasUsoActual { get; set; }

        [Required(ErrorMessage = "Horas de Uso Máximo es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El Campo solo puede contener números.")]
        public int HorasUsoMaximo { get; set; }

        [Required(ErrorMessage = "Horas de Uso Mantenimiento es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El Campo solo puede contener números.")]
        public int HorasMantenimiento { get; set; }
    }
}
