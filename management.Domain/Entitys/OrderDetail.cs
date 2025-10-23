namespace management.Domain.Entitys;

public class OrderDetail
{

    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public Order order { get; set; }
    //public Product? Product { get; set; }
    // 🧮 Propiedad calculada (no se mapea a la BD)
    public double Total => Quantity * UnitPrice;

}