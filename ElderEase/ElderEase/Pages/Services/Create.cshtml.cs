using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElderEase.Data;
using ElderEase.Models;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace ElderEase.Pages.Services
{
    public class CreateModel : PageModel
    {
        private readonly ElderEase.Data.ElderEaseContext _context;

        public CreateModel(ElderEase.Data.ElderEaseContext context)
        {
            _context = context;
        }

        public int Id { get; set; }
        public IActionResult OnGet(int id)
        {
            Id = id;
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Service.Add(Service);
            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == Id);
            if (provider == null)
            {
                return NotFound();
            }
            provider.services.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
