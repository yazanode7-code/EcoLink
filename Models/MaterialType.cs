using System.ComponentModel.DataAnnotations;
using EcoLink.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

[Index(nameof(Name), IsUnique = true)]
public class MaterialType : BaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    [Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Points per kg must be greater than zero")]
    [Display(Name = "Points per Kg")]
    public int PointsPerKg { get; set; }

    [Display(Name = "Active")]
    public bool IsActive { get; set; } = true;

    public ICollection<Bin> Bins { get; set; } = new List<Bin>();
}
