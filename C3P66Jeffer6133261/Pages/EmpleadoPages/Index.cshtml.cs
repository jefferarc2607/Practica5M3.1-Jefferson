using C3P66Jeffer6133261.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace C3P66Jeffer6133261.Pages.EmpleadoPages
{
    public class IndexModel : PageModel
    {
        private readonly C3P66Jeffer6133261Context _context;

        public IndexModel(C3P66Jeffer6133261Context context)
        {
            _context = context;
        }

        public IList<EmpleadoContable> EmpleadosContables { get; set; }

        public async Task OnGetAsync()
        {
            EmpleadosContables = await _context.EmpleadosContables.ToListAsync<EmpleadoContable>();
        }
    }
}
