using System.ComponentModel.DataAnnotations;

namespace C3P66Jeffer6133261.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Phone(ErrorMessage = "Teléfono no válido")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "Email no válido")]
        public string Email { get; set; }

        [Range(0, 9999, ErrorMessage = "Las compras deben ser entre 0 y 9999")]
        public int CantidadCompras { get; set; }
    }
}
