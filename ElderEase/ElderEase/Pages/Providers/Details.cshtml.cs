using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ElderEase.Data;
using ElderEase.Models;

namespace ElderEase.Pages.Providers
{
    public class DetailsModel : PageModel
    {
        private readonly ElderEase.Data.ElderEaseContext _context;

        public DetailsModel(ElderEase.Data.ElderEaseContext context)
        {
            _context = context;
        }

        public Provider Provider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }
            else
            {
                Provider = provider;
            }
            return Page();
        }
    }
}
