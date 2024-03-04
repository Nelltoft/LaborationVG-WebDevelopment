using LaborationVG.Data;
using LaborationVG.Interfaces;
using LaborationVG.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LaborationVG.Services;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, AuthenticationStateProvider auth)
    {
        _context = context;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        var result = await _context.Books.ToListAsync();
        return result;
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var result = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (result is not null)
        {
            return result;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
    public async Task UpdateBook(Book book)
    {
        _context.Books.Where(b => b.Id == book.Id).ExecuteUpdate(s => s.SetProperty(b => b.Quantity, book.Quantity));
        await _context.SaveChangesAsync();
    }

    public async Task<Cart> GetCartAsync(string id)
    {
        var cart = await _context.Carts
                .Include(c => c.User)
                .Include(c => c.CartBooks)!.ThenInclude(cb => cb.Book)
                .FirstOrDefaultAsync(c => c.User.Id == id);
        if (cart is not null)
        {
            return cart;
        }
        else
        {
            return await CreateCart(id);
        }
    }

    public async Task<Cart> CreateCart(string id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        var cart = new Cart { User = user! };
        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();
        return cart;
    }

    public async Task AddProductToCart(CartBook cartBook)
    {
        CartBook addCartBook = new CartBook { CartId = cartBook.CartId, BookId = cartBook.BookId, Quantity = 1 };
        var result = await _context.CartBooks.FirstOrDefaultAsync(cb => (cb.CartId == addCartBook.CartId) && (cb.BookId == addCartBook.BookId));

        if (result is not null)
        {
            result.Quantity++;
            await _context.SaveChangesAsync();
            return;
        }
        _context.CartBooks.Add(addCartBook);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductFromCart(int id)
    {
        var productToDelete = _context.CartBooks.FirstOrDefault(cb => cb.Id == id);
        if (productToDelete?.Quantity > 1)
        {
            productToDelete.Quantity--;
            await _context.SaveChangesAsync();
            return;
        }
        _context.CartBooks.Remove(productToDelete!);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAllProductsFromCart(int id)
    {
        var productToDelete = _context.CartBooks.FirstOrDefault(cb => cb.Id == id);

        _context.CartBooks.Remove(productToDelete!);
        await _context.SaveChangesAsync();
    }

    public bool CartExists(string id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        return _context.Carts.Any(c => c.User == user);
    }
}
