using LaborationVG.Data;
using LaborationVG.Models;

namespace LaborationVG;

public class Seed
{
    private readonly ApplicationDbContext _context;

    public Seed(ApplicationDbContext context)
    {
        _context = context;
    }

    public void SeedDatabase()
    {
        if (!_context.Books.Any()) 
        {
            var books = new List<Book>()
            {
                new Book
                {
                    Name = "Dune",
                    Description = "Set on the desert planet Arrakis, Dune is the story of the boy Paul Atreides, heir to a noble family tasked with ruling an inhospitable world where the only thing of value is the “spice” melange, a drug capable of extending life and enhancing consciousness.",
                    Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1555447414i/44767458.jpg",
                    Price = 15.99,
                    Quantity = 15
                },
                new Book
                {
                    Name = "Foundation",
                    Description = "The Galactic Empire has prospered for twelve thousand years. Nobody suspects that the heart of the thriving Empire is rotten, until psychohistorian Hari Seldon uses his new science to foresee its terrible fate.",
                    Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1520376086i/39037823.jpg",
                    Price = 9.99,
                    Quantity = 10
                },
                new Book
                {
                    Name = "The Wheel of Time, The Eye of the World",
                    Description = "When their village is attacked by terrifying creatures, Rand al'Thor and his friends are forced to flee for their lives. An ancient evil is stirring, and its servants are scouring the land for the Dragon Reborn - the prophesised hero who can deliver the world from darkness.",
                    Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1627667880i/58663212.jpg",
                    Price = 13.49,
                    Quantity = 5
                },
                new Book
                {
                    Name = "Skyward",
                    Description = "Defeated, crushed, and driven almost to extinction, the remnants of the human race are trapped on a planet that is constantly attacked by mysterious alien starfighters. Spensa, a teenage girl living among them, longs to be a pilot. When she discovers the wreckage of an ancient ship, she realizes this dream might be possible—assuming she can repair the ship, navigate flight school, and (perhaps most importantly) persuade the strange machine to help her. Because this ship, uniquely, appears to have a soul.",
                    Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1531845177i/36642458.jpg",
                    Price = 10,
                    Quantity = 20
                },
                new Book
                {
                    Name = "Children of Time",
                    Description = "The last remnants of the human race left a dying Earth, desperate to find a new home among the stars. Following in the footsteps of their ancestors, they discover the greatest treasure of the past age—a world terraformed and prepared for human life.",
                    Image = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1431014197i/25499718.jpg",
                    Price = 8.09,
                    Quantity = 25
                }
            };
            _context.Books.AddRange(books);
            _context.SaveChanges();
        }
    }
}
