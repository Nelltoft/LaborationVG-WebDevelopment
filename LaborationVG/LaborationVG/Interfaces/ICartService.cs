using LaborationVG.Models;

namespace LaborationVG.Interfaces;

public interface ICartService
{
    Task<Cart> GetCart(string id);
    Task AddProductToCart(string userId, Book book);
    Task DeleteProductInCart(string userId, Book book);
    Task DeleteAllInCart(string userId);
}
