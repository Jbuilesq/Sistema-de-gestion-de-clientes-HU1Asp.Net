namespace management.Domain.Entitys;

public class Order
{
    public int Id { get; set; }
    public string Status  { get; set; } = "Pending";
    public int CustomerId { get; set; }
    public Customer? customer { get; set; }
    
    public IEnumerable<Product>? products { get; set; } = new List<Product>(); 
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
}