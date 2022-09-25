using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InventoryApp.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        IList<Product> productList = await _productRepository.GetAll();

        return View(productList);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        try
        {
            if (!ModelState.IsValid) return View(product);

            await _productRepository.Create(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return RedirectToAction("Index");
    }

}