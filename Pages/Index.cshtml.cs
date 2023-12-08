using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.Models;
using Proyecto1.Services;

namespace Proyecto1.Pages;

public class IndexModel : PageModel
{

    public List<Movie> MovieList { get; set; }
    //Mapeo de las propiedades de la clase NewMovie
    [BindProperty]
    public Movie NewMovie { get; set; }
    public IndexModel()
    {
        //Constructor
    }

    public void OnGet()
    {
        MovieList = MovieService.GetAll();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return RedirectToPage("/Error");
        }
        MovieService.Add(NewMovie);
        return RedirectToAction("get");
    }
}
