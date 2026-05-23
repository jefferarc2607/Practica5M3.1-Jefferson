using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C3P66Jeffer6133261.Pages
{
    public class IndexModel : PageModel
    {
        public string MensajeBienvenida { get; set; }

        public void OnGet()
        {
            MensajeBienvenida = "Sistema de Gestión Empresarial";
        }
    }
}
