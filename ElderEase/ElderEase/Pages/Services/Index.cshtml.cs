using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ElderEase.Data;
using ElderEase.Models;

namespace ElderEase.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly ElderEase.Data.ElderEaseContext _context;

        public IndexModel(ElderEase.Data.ElderEaseContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;

        public int Id { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Id = (int)id;
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }
            Service = (IList<Service>)provider.services;
            return Page();
        }
    }
}
