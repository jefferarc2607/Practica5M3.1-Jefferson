using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorC3Jeffer6133261.Models;

namespace RazorC3Jeffer6133261.Pages.EmpleadoDeveloperPages;

public class IndexModel : PageModel
{
    private readonly RazorC3Jeffer6133261Context _context;

    public IndexModel(RazorC3Jeffer6133261Context context)
    {
        _context = context;
    }

    public IList<EmpleadoDeveloper> EmpleadoDeveloper { get; set; } = default!;

    public async Task OnGetAsync()
    {
        EmpleadoDeveloper = await _context.EmpleadoDeveloper.ToListAsync();
    }
}
