﻿using System.Collections.Generic;

namespace P1_FloricelaArguedas_WebAppJHH.Models
{
    public class Mantenimiento
    {
        public int Id { get; set; }

        public  int IdCliente { get; set; }

        public  DateTime FechaEjecutado { get; set; }

        public DateTime FechaAgendado { get; set; }

        public  int m2Propiedad { get; set; }

        public  int m2CercaViva { get; set; }

        public string EstadoMantenimiento { get; set; }

        //CAMPO AUTOCALCULADO

        public  int DiasSinChapia { get; set; }

        //CAMPO AUTOCALCULADO
        public  DateTime FechaSiguienteChapia { get; set; }

        public string TipoZacate { get; set; }

        public string ProductoAplicado { get; set; }

        public string TipoProductoAplicado { get; set; }

        public  int CostoChapiaM2 { get; set; }

        public  int CostoProductoM2 { get; set; }

        //CAMPO AUTOCALCULADO
        public  float CostoTotalMantenimiento { get; set; }
        
    }
}
