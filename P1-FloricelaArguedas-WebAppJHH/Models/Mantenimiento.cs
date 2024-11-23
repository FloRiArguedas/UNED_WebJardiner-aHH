using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P1_FloricelaArguedas_WebAppJHH.Models
{
    public class Mantenimiento
    {
        [Required(ErrorMessage = "El ID es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El ID solo puede contener números.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El ID solo puede contener números.")]
        public  int IdCliente { get; set; }

        [Required(ErrorMessage = "Fecha Ejecutado es obligatorio.")]
        public  DateTime FechaEjecutado { get; set; }

        [Required(ErrorMessage = "Fecha Agendado es obligatorio.")]
        public DateTime FechaAgendado { get; set; }

        [Required(ErrorMessage = "Los M2 de Propiedad sin chapia son obligatorios.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
        public  int m2Propiedad { get; set; }

        [Required(ErrorMessage = "Los M2 Cerca Viva sin chapia son obligatorios.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
        public  int m2CercaViva { get; set; }

        [Required(ErrorMessage = "Estado Mantenimiento es obligatorio.")]
        public string EstadoMantenimiento { get; set; }

        //CAMPO AUTOCALCULADO
        [Required(ErrorMessage = "Los días sin chapia son obligatorios.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
        public  int DiasSinChapia { get; set; }

        //CAMPO AUTOCALCULADO

        [Required(ErrorMessage = "Los Fecha Siguiente Chapia es obligatorio.")]
        public  DateTime FechaSiguienteChapia { get; set; }

        public string TipoZacate { get; set; }

        public string ProductoAplicado { get; set; }

        public string TipoProductoAplicado { get; set; }

        [Required(ErrorMessage = "El costo de chapia es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
        public  int CostoChapiaM2 { get; set; }

        [Required(ErrorMessage = "El costo de aplicar producto es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
        public  int CostoProductoM2 { get; set; }

        //CAMPO AUTOCALCULADO
        [Required(ErrorMessage = "El costo total es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo solo puede contener números.")]
        public  float CostoTotalMantenimiento { get; set; }
        
    }
}
