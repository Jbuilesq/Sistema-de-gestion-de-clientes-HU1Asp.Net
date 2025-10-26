namespace management.Application.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class CustomerCreateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}

public class CustomerUpdateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}
