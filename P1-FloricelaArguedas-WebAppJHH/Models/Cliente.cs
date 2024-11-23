using System.ComponentModel.DataAnnotations;

namespace P1_FloricelaArguedas_WebAppJHH.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El ID solo puede contener números.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El nombre no puede tener más de 20 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Provincia es obligatorio.")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Cantón es obligatorio.")]
        public string Canton { get; set; }

        [Required(ErrorMessage = "Distrito es obligatorio.")]
        public string Distrito { get; set; }

        [Required(ErrorMessage = "Direccion Exacta es obligatorio.")]
        public string DireccionExacta { get; set; }

        [Required(ErrorMessage = "Indicar el Mantenimiento es obligatorio.")]
        public string MantenimientoInvierno { get; set; }

        [Required(ErrorMessage = "Indicar el Mantenimiento es obligatorio.")]
        public string MantenimientoVerano { get; set; }
    }
}
