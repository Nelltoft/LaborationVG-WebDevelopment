namespace LaborationVG.Shared.Interfaces;

public interface IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
