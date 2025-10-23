using System.ComponentModel.DataAnnotations;

namespace management.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    // public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class ProductCreateDto
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(50,MinimumLength = 3, ErrorMessage = "El nombre debe contener entre 3 y 50 caracteres")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La descripcion es requerida")]
    [StringLength(100,ErrorMessage = "El mensaje debe contener maximo 100 caracteres")]
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    // public bool IsActive { get; set; } = true;
}

public class ProductUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    // public bool IsActive { get; set; } = true;
}