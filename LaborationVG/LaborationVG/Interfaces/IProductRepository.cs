using LaborationVG.Models;

namespace LaborationVG.Interfaces;

public interface IProductRepository
{
    Task<List<Book>> GetBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task<Cart> GetCartAsync(string id);
    Task AddProductToCart(CartBook cartBook);
    Task DeleteProductFromCart(int id);
    Task DeleteAllProductsFromCart(int id);
    Task UpdateBook(Book book);
    Task<Cart> CreateCart(string id);
    bool CartExists(string id);
}
