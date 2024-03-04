using LaborationVG.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaborationVG.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController : Controller
{
    private readonly IProductRepository _productRepository;

    public PurchaseController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpDelete("{id}")]
    public async Task DeleteAllInCart(int id)
    {
        await _productRepository.DeleteAllProductsFromCart(id);
    }
}
