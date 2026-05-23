using System.ComponentModel.DataAnnotations;

namespace C3P66Jeffer6133261.Models
{
    public abstract class EmpleadoBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Range(18, 99, ErrorMessage = "La edad debe estar entre 18 y 99")]
        public int Edad { get; set; }

        [EmailAddress(ErrorMessage = "Email no válido")]
        public string Email { get; set; }
    }
}
