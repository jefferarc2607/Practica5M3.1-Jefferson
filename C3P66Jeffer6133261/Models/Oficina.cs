using System.ComponentModel.DataAnnotations;

namespace C3P66Jeffer6133261.Models
{
    public class Oficina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La ubicación es obligatoria")]
        [StringLength(100)]
        public string Ubicacion { get; set; }

        [Range(1, 500, ErrorMessage = "La capacidad debe ser entre 1 y 500")]
        public int CantidadMaximaEmpleados { get; set; }

        public bool AtencionClientes { get; set; }
    }
}
