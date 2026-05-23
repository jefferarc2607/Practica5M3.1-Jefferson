using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C3P66Jeffer6133261.Pages
{
    public class OficinaInfo
    {
        public int Id { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }
        public bool AtencionPublico { get; set; }
    }
    public class OficinasModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public List<OficinaInfo> Oficinas { get; set; }

        public void OnGet()
        {
            if (id == 0)
            {
                id = 1;
            }

            Oficinas = new List<OficinaInfo>
            {
                new OficinaInfo { Id = 1, Ubicacion = "Centro", Capacidad = 20, AtencionPublico = true },
                new OficinaInfo { Id = 2, Ubicacion = "Norte", Capacidad = 15, AtencionPublico = false },
                new OficinaInfo { Id = 3, Ubicacion = "Sur", Capacidad = 25, AtencionPublico = true },
                new OficinaInfo { Id = 4, Ubicacion = "Este", Capacidad = 10, AtencionPublico = false }
            };
        }
    }
}
