
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products;
public class AddProductModel : PageModel
{
    private readonly ILogger<AddProductModel> _logger;
    private WiredContext _context;
    private IWebHostEnvironment _webEnv;

    [BindProperty]
    public Product NewProduct { get; set; }

    public AddProductModel(ILogger<AddProductModel> logger, WiredContext context, IWebHostEnvironment environment)
    {
        _logger = logger;
        _context = context;
        _webEnv = environment;
    }



    public void OnGet() { }

    public async Task<IActionResult> OnPost()
    {

        if (!ModelState.IsValid) { return Page(); }

        if (NewProduct.Upload is not null)
        {
            NewProduct.ImageFileName = NewProduct.Upload.FileName;
            var filePath = Path.Combine(_webEnv.ContentRootPath, "wwwroot/images/menu", NewProduct.Upload.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await NewProduct.Upload.CopyToAsync(fileStream);
            }
        }

        NewProduct.Created = DateTime.Now;
        //save product to db
        _context.Products.Add(NewProduct);
        _context.SaveChanges();
        return RedirectToPage("ViewAllProducts");
    }
}