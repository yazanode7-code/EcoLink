using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

/// <summary>
/// منتجات المصنع اللي بتنشرى بالنقاط.
/// </summary>
public class FactoryProduct : BaseEntity
{
    [Required]
    [Display(Name = "المصنع")]
    public int FactoryId { get; set; }

    [ForeignKey(nameof(FactoryId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Factory Factory { get; set; } = null!;

    [Required(ErrorMessage = "اسم المنتج مطلوب")]
    [StringLength(255)]
    [Display(Name = "اسم المنتج")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "الوصف")]
    public string? Description { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "السعر لازم يكون أكبر من صفر")]
    [Display(Name = "السعر بالنقاط")]
    public int PointsCost { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "الكمية ما بتكون سالبة")]
    [Display(Name = "الكمية المتوفرة")]
    public int StockQuantity { get; set; }

    [Display(Name = "مفعّل")]
    public bool IsActive { get; set; } = true;

    public ICollection<RewardOrder> RewardOrders { get; set; } = new List<RewardOrder>();
}
