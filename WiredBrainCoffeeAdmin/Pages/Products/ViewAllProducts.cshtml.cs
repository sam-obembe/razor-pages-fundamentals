using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products;
public class ViewAllProductsModel : PageModel
{
    private IProductRepository productRepository;

    public List<Product> Products { get; set; }

    public ViewAllProductsModel(IProductRepository repository)
    {
        productRepository = repository;
    }

    public void OnGet()
    {
        Products = productRepository.GetAll();
    }
}