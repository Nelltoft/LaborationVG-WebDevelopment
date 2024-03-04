using LaborationVG.Interfaces;
using LaborationVG.Models;

namespace LaborationVG.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _http;
    public string[] localHost = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")!.Split(";");

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Book>> GetProducts()
    {        
        var books = await _http.GetFromJsonAsync<List<Book>>($"{localHost[0]}/api/book");
        if (books is not null) 
        { 
            return books;
        }
        else 
        { 
            throw new InvalidOperationException();
        }
    }

    public async Task<Book> GetProduct(int id)
    {        
        var book = await _http.GetFromJsonAsync<Book>($"{localHost[0]}/api/book/{id}");
        if (book is not null)
        {
            return book;
        }
        else 
        { 
            throw new InvalidOperationException(); 
        }
    }

    public async Task SubtractProductQuantity(Book book)
    {
        book.Quantity -= 1;
        await _http.PutAsJsonAsync($"{localHost[0]}/api/book/{book.Id}", book);
    }

    public async Task AddProductQuantity(Book book)
    {
        book.Quantity += 1;
        await _http.PutAsJsonAsync($"{localHost[0]}/api/book/{book.Id}", book);
    }
}
