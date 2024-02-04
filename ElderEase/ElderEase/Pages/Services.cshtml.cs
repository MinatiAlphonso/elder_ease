using ElderEase.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ElderEase.Pages
{
    public class ServicesModel : PageModel
    {
        private readonly ElderEase.Data.ElderEaseContext _context;

        public ServicesModel(ElderEase.Data.ElderEaseContext context)
        {
            _context = context;
        }

        public IList<Provider> Provider { get; set; } = default!;
        public IList<Provider> FilteredProviders { get; set; } = default!;

        public async Task OnGetAsync(string providerSearch, string search, string filter)
        {
            var query = await _context.Providers.Include(p => p.services).ToListAsync();

            // Apply search logic for providers
            if (!string.IsNullOrWhiteSpace(providerSearch))
            {
                query = query.Where(p =>
                    p.firstName.Contains(providerSearch, StringComparison.OrdinalIgnoreCase) ||
                    p.lastName.Contains(providerSearch, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Apply search and filter logic for services
            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchServiceName = Enum.TryParse<ServiceNames>(search, out var serviceName)
                    ? serviceName
                    : ServiceNames.HomeNurse; // Default to HomeNurse if parsing fails

                query = query.Where(p =>
                    p.services.Any(s => s.serviceName == searchServiceName)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {
                var filterServiceType = Enum.TryParse<ServiceTypes>(filter, out var serviceType)
                    ? serviceType
                    : ServiceTypes.Free;

                query = query.Where(p =>
                    p.services.Any(s => s.serviceType == filterServiceType)).ToList();
            }

            FilteredProviders = query;
        }
    }
}
