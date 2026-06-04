using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace RazorC3Jeffer6133261.Pages
{
    public class OficinasModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
           if (Id == 0)
           {
               Id = 1; 
           }
        }
    }
}
