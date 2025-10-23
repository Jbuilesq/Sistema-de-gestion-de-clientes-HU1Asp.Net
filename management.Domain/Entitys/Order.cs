namespace management.Domain.Entitys;

public class Order
{
    public int Id { get; set; }
    public int CustumerId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string Status  { get; set; } = "Pending";
    
    public Customer customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    
}