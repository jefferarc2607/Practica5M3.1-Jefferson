using System.ComponentModel.DataAnnotations;

namespace C3P66Jeffer6133261.Models
{
    public class EmpleadoContable : EmpleadoBase
    {
        [Range(0, 9999)]
        public int RegistrosCreados { get; set; }

        [Range(0, 9999)]
        public int FacturasCreadas { get; set; }
    }
}
