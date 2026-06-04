using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorC3Jeffer6133261.Models;

namespace RazorC3Jeffer6133261.Pages.ClientePages;

public class IndexModel : PageModel
{
    private readonly RazorC3Jeffer6133261Context _context;

    public IndexModel(RazorC3Jeffer6133261Context context)
    {
        _context = context;
    }

    public IList<Cliente> Cliente { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Cliente = await _context.Cliente.ToListAsync();
    }
}
