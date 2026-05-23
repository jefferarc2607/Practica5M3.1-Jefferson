using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C3P66Jeffer6133261.Pages.Empleados
{
    public class EmpleadoContableInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public int RegistrosCreados { get; set; }
        public int FacturasProcesadas { get; set; }
    }

    public class ContabilidadModel : PageModel
    {
        public List<EmpleadoContableInfo> EmpleadosContables { get; set; }

        public void OnGet()
        {
            EmpleadosContables = new List<EmpleadoContableInfo>
            {
                new EmpleadoContableInfo { Id = 1, Nombre = "Ana López", Edad = 32, Email = "ana@empresa.com", RegistrosCreados = 150, FacturasProcesadas = 45 },
                new EmpleadoContableInfo { Id = 2, Nombre = "Carlos Ruiz", Edad = 28, Email = "carlos@empresa.com", RegistrosCreados = 89, FacturasProcesadas = 23 },
                new EmpleadoContableInfo { Id = 3, Nombre = "María Paz", Edad = 35, Email = "maria@empresa.com", RegistrosCreados = 210, FacturasProcesadas = 67 }
            };
        }
    }
}
