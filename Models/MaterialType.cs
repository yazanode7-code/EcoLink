using System.ComponentModel.DataAnnotations;
using EcoLink.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

/// <summary>
/// Lookup Table — أنواع المواد وسعر الكيلو بالنقاط.
/// </summary>
[Index(nameof(Name), IsUnique = true)]
public class MaterialType : BaseEntity
{
    [Required(ErrorMessage = "الاسم بالإنجليزي مطلوب")]
    [StringLength(100)]
    [Display(Name = "الاسم (EN)")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "الاسم بالعربي مطلوب")]
    [StringLength(100)]
    [Display(Name = "الاسم")]
    public string NameAr { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "النقاط لازم تكون أكبر من صفر")]
    [Display(Name = "نقاط لكل كيلو")]
    public int PointsPerKg { get; set; }

    [Display(Name = "مفعّلة")]
    public bool IsActive { get; set; } = true;

    public ICollection<Bin> Bins { get; set; } = new List<Bin>();
}
