using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorC3Jeffer6133261.Pages
{
    public class ClientesModel : PageModel
    {
        public List <string> Clientes { get; set; }
    
        public void OnGet()
        {
            Clientes = new List<string>
            {
                "Juan Perez",
                "Maria Garcia",
                "Carlos Lopez",
                "Ana Rodriguez"
            };
        }
    }
}
