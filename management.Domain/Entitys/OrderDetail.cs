namespace management.Domain.Entitys;

public class OrderDetail
{

    public int Id { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    
    public int OrderId { get; set; }
    public Order order { get; set; }
    // 🧮 Propiedad calculada (no se mapea a la BD)
    public double Total => Quantity * UnitPrice;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

}                       