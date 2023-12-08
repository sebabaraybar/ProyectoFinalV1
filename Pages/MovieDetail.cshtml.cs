using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.Models;
using Proyecto1.Services;

namespace Proyecto1.Pages
{
    public class MovieDetailModel : PageModel
    {
        //Hay que instanciar (podría instanciarse también en un constructor)
        public Movie MovieDetail { get; set; } = new();
        public void OnGet(string code)
        {
            if (code != null)
            {
                var responseServiceData = MovieService.Get(code);
                if (responseServiceData != null)
                {
                    MovieDetail = responseServiceData;
                }
            }
        }

        public IActionResult OnPostDelete(string code)
        {
            if (code != null)
            {
                MovieService.Delete(code);
            }
            return RedirectToPage("Index");
        }
    }
}
