using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using C3P66Jeffer6133261.Models;

namespace C3P66Jeffer6133261.Pages.EmpleadoPages;

public class CreateModel : PageModel
{
    private readonly C3P66Jeffer6133261Context _context;

    public CreateModel(C3P66Jeffer6133261Context context)
    {
        _context = context;
    }

    [BindProperty]
    public EmpleadoContable EmpleadoContable { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.EmpleadosContables.Add(EmpleadoContable);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
