using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorC3Jeffer6133261.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string nombre { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                nombre = "Empleado 1";
            }
        }
    }
}
