using management.Domain.Entitys;

namespace management.Application.DTOs;

public class OrderDTOs
{
    public int Id { get; set; }
    public string Status  { get; set; } = "Pending";
    public string? customer { get; set; }
    
    public IEnumerable<string>? products { get; set; } = new List<string>(); 
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class OrderCreateDTOs
{
    public int CustomerId { get; set; }
    public List<int> ProductIds { get; set; } = new();

    public string Status  { get; set; } = "Pending";
}

public class OrderUpdateDTOs
{
    public int CustomerId { get; set; }
    public List<int> ProductIds { get; set; } = new();

    public string Status  { get; set; } = "Pending";
    
}