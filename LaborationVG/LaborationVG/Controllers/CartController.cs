using LaborationVG.Interfaces;
using LaborationVG.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaborationVG.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : Controller
{
    private readonly IProductRepository _productRepository;

    public CartController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("{id}")]
    public async Task<Cart> GetCartByUserId(string id)
    {
        var cart = await _productRepository.GetCartAsync(id);
        if (cart is not null)
        {
            return cart;
        }
        else
        {
            return null!;
        }
    }

    [HttpPost]
    public async Task AddProductToCart(CartBook cartBook)
    {
        await _productRepository.AddProductToCart(cartBook);
    }

    [HttpDelete("{id}")]
    public async Task DeleteProductInCart(int id)
    {
        await _productRepository.DeleteProductFromCart(id);
    }
}
