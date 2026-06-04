using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorC3Jeffer6133261.Models;

namespace RazorC3Jeffer6133261.Pages.OficinaPages;

public class CreateModel : PageModel
{
    private readonly RazorC3Jeffer6133261Context _context;

    public CreateModel(RazorC3Jeffer6133261Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Oficina Oficina { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Oficina.Add(Oficina);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
