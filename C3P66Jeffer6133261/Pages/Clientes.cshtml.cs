using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C3P66Jeffer6133261.Pages
{
    // Clase que representa un Cliente (Modelo como enseña página 69-71)
    public class ClienteInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int TotalCompras { get; set; }
    }
    public class ClientesModel : PageModel
    {
        public ClienteInfo[] ListaClientes { get; set; }
        public void OnGet()
        {
            // ejercicio 2 crear arreglo de tipo string
            ListaClientes = new ClienteInfo[]
            {
            // clientes de ejemplo
            (new ClienteInfo { Id = 1, Nombre = "Juan Pérez", Telefono = "555-0101", Email = "juan@email.com", TotalCompras = 5 }),
            (new ClienteInfo { Id = 2, Nombre = "María García", Telefono = "555-0102", Email = "maria@email.com", TotalCompras = 12 }),
            (new ClienteInfo { Id = 3, Nombre = "Carlos López", Telefono = "555-0103", Email = "carlos@email.com", TotalCompras = 3 }),
            (new ClienteInfo { Id = 4, Nombre = "Ana Rodríguez", Telefono = "555-0104", Email = "ana@email.com", TotalCompras = 8 })
            };
        }
    }
    
}
