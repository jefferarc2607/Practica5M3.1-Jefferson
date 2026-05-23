using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C2P40Jeffer6133261.Pages
{
    public class IndexModel : PageModel
    {
        public string visitante { get; set; }
        public string fecha { get; set; }
        public List<string> visitantes { get; set; }

        public DateTime fechaCreacion { get; set; }
        public int diasTranscurridos { get; set; }

        public void OnGet()
        {
            visitante = "Santiago";

            fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            visitantes = new List<string>();
            visitantes.Add("Matías");
            visitantes.Add("Micaela");
            visitantes.Add("Andrés");
            visitantes.Add("Marta");

            // ejercicios practicos 2, 3 y 4

            // ejercicio 2 crear objeto fechaCreacion
            fechaCreacion = new DateTime(2026, 5, 17); 

            // ejercicio 3 capturar fecha actual en OnGet()
            DateTime fechaActual = DateTime.Now;

            // ejercicio 4 calcular diferencia de días
            TimeSpan diferencia = fechaActual - fechaCreacion;
            diasTranscurridos = diferencia.Days;
        }
    }
}
