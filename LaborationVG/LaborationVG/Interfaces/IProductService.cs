using LaborationVG.Models;

namespace LaborationVG.Interfaces;

public interface IProductService
{
    Task<List<Book>> GetProducts();
    Task<Book> GetProduct(int id);
    Task SubtractProductQuantity(Book book);
    Task AddProductQuantity(Book book);
}
