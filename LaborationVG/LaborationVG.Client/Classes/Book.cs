namespace LaborationVG.Client.Classes;

public class Book
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public List<CartBook>? CartBooks { get; set; }
}
