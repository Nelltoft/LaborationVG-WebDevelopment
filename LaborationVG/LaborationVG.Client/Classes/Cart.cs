namespace LaborationVG.Client.Classes;

public class Cart
{
    public int Id { get; set; }
    public required User User { get; set; }
    public List<CartBook>? CartBooks { get; set; }
}
