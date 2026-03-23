namespace ApiAppStudy.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Activity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    [Column("create_date")]
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}
