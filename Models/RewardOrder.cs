using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using EcoLink.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

/// <summary>
/// طلب مكافأة — من المصنع للجامعة.
/// CreatedAt (من BaseEntity) = تاريخ الطلب.
/// </summary>
public class RewardOrder : BaseEntity
{
    [Required]
    [Display(Name = "الفرع")]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Branch Branch { get; set; } = null!;

    // موظف الجامعة اللي طلب
    [Required]
    [Display(Name = "مقدّم الطلب")]
    public int RequestedByEmployeeId { get; set; }

    [ForeignKey(nameof(RequestedByEmployeeId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser RequestedByEmployee { get; set; } = null!;

    [Required(ErrorMessage = "المنتج مطلوب")]
    [Display(Name = "المنتج")]
    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public FactoryProduct Product { get; set; } = null!;

    [Required]
    [Range(1, 1000, ErrorMessage = "الكمية غير صحيحة")]
    [Display(Name = "الكمية")]
    public int Quantity { get; set; } = 1;

    // Snapshot لسعر المنتج وقت الطلب
    [Required]
    [Display(Name = "النقاط المصروفة")]
    public int PointsSpent { get; set; }

    // سواق المصنع
    [Display(Name = "السائق")]
    public int? DriverId { get; set; }

    [ForeignKey(nameof(DriverId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser? Driver { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]   // بيخزن الـ enum كنص
    [Display(Name = "الحالة")]
    public RewardOrderStatus Status { get; set; } = RewardOrderStatus.Pending;

    [Display(Name = "تاريخ التسليم")]
    public DateTime? DeliveredDate { get; set; }
}
