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
          [BindProperty]
        public Provider Provider { get; set; } = default!;
        public CreateModel(ElderEase.Data.ElderEaseContext context)
        {
            _context = context;
        }
     
        public IActionResult OnGet()
        {
            ServiceNameList = Enum.GetValues(typeof(ServiceNames))
           .Cast<ServiceNames>()
           .Select(s => new SelectListItem
           {
             Value = s.ToString(),
             Text = EnumHelper.GetDescription(s)// Assuming you have the GetDescription extension method
        })
         .ToList();
            return Page();
        }
        public List<SelectListItem> ServiceNameList { get; set; }

        public Service newService = new Service();
        public List<Service> selectedServices = new List<Service>();

       
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

            return RedirectToPage("./Services/Index?Id=" + Provider.Id);
        }
    }
}
