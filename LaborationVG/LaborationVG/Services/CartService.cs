using LaborationVG.Interfaces;
using LaborationVG.Models;

namespace LaborationVG.Services;

public class CartService : ICartService
{
    private readonly HttpClient _http;
    public string[] localHost = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")!.Split(";");

    public CartService(HttpClient http)
    {
        _http = http;
    }

    public async Task<Cart> GetCart(string id)
    {
        var cart = await _http.GetFromJsonAsync<Cart>($"{localHost[0]}/api/cart/{id}");
        if (cart is not null)
        {
            return cart;
        }
        else
        {
            return null!;
        }
    }

    public async Task AddProductToCart(string userId, Book book)
    {
        var cart = await _http.GetFromJsonAsync<Cart>($"{localHost[0]}/api/cart/{userId}");
        if (cart is not null)
        {
            var cartBook = new CartBook { CartId = cart.Id, Cart = cart, BookId = book.Id, Book = book };
            await _http.PostAsJsonAsync($"{localHost[0]}/api/cart", cartBook);
        }
    }

    public async Task DeleteProductInCart(string userId, Book book)
    {
        var cart = await _http.GetFromJsonAsync<Cart>($"{localHost[0]}/api/cart/{userId}");
        if (cart is not null && cart.CartBooks is not null)
        {
            var cartBook = cart.CartBooks.FirstOrDefault(cb => (cb.CartId == cart.Id) && (cb.BookId == book.Id));
            await _http.DeleteAsync($"{localHost[0]}/api/cart/{cartBook!.Id}");
        }
    }

    public async Task DeleteAllInCart(string userId)
    {
        var cart = await _http.GetFromJsonAsync<Cart>($"{localHost[0]}/api/cart/{userId}");

        if (cart is not null && cart.CartBooks is not null)
        {
            foreach (var cartBook in cart.CartBooks)
            {
                await _http.DeleteAsync($"{localHost[0]}/api/purchase/{cartBook!.Id}");
            }
        }
    }
}
