using System.ComponentModel.DataAnnotations;

namespace ApiAppStudy.DTOs;

public class CreateActivityDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
}
