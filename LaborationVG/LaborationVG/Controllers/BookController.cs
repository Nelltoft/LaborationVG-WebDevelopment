using LaborationVG.Interfaces;
using LaborationVG.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaborationVG.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : Controller
{
    private readonly IProductRepository _productRepository;

    public BookController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
    public async Task<List<Book>> GetAllBooks()
    {
        var books = await _productRepository.GetBooksAsync();
        return books;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _productRepository.GetBookByIdAsync(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [HttpPut("{id}")]
    public async Task UpdateBook(Book book)
    {
        await _productRepository.UpdateBook(book);
    }
}
