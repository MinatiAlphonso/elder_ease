using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElderEase.Data;
using ElderEase.Models;
using Microsoft.EntityFrameworkCore;

namespace ElderEase.Pages.Providers
{
    public class CreateModel : PageModel
    {
        private readonly ElderEase.Data.ElderEaseContext _context;

        public CreateModel(ElderEase.Data.ElderEaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Provider Provider { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                // Log or inspect validation errors
                foreach (var entry in ModelState.Values)
                {
                    foreach (var error in entry.Errors)
                    {
                        // Log or handle error messages
                        Console.WriteLine($"Property: Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            _context.Providers.Add(Provider);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
