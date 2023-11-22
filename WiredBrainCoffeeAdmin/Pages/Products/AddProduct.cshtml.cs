
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products;
public class AddProductModel : PageModel
{
    private readonly ILogger<AddProductModel> _logger;

    public AddProductModel(ILogger<AddProductModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public Product NewProduct { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        //save product to db
        if (ModelState.IsValid)
        {
            _logger.LogInformation(NewProduct.Name);
            return RedirectToPage("ViewAllProducts");
        }

        return Page();

    }
}