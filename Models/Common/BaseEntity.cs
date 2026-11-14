using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Common;

public abstract class BaseEntity : IAuditable
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }
}
