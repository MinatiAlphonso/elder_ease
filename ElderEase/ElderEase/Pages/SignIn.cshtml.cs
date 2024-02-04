using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElderEase.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Role { get; set; }

        public void OnGet()
        {
        }
    }
}
