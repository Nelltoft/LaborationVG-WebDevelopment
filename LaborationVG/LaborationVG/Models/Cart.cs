using LaborationVG.Data;
using System.ComponentModel.DataAnnotations;

namespace LaborationVG.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }
    public required ApplicationUser User { get; set; }
    public List<CartBook>? CartBooks { get; set; }
}
