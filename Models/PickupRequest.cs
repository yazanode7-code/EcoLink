using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using EcoLink.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

/// <summary>
/// طلب تفريغ سلة — من الجامعة للمصنع.
/// CreatedAt (من BaseEntity) = تاريخ الطلب.
/// </summary>
public class PickupRequest : BaseEntity
{
    [Required]
    [Display(Name = "السلة")]
    public int BinId { get; set; }

    [ForeignKey(nameof(BinId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Bin Bin { get; set; } = null!;

    // موظف الجامعة اللي بلّغ
    [Required]
    [Display(Name = "المبلّغ")]
    public int ReportedByEmployeeId { get; set; }

    [ForeignKey(nameof(ReportedByEmployeeId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser ReportedByEmployee { get; set; } = null!;

    [Display(Name = "المصنع")]
    public int? FactoryId { get; set; }

    [ForeignKey(nameof(FactoryId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Factory? Factory { get; set; }

    // سواق المصنع
    [Display(Name = "السائق")]
    public int? DriverId { get; set; }

    [ForeignKey(nameof(DriverId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser? Driver { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]   // بيخزن الـ enum كنص
    [Display(Name = "الحالة")]
    public PickupStatus Status { get; set; } = PickupStatus.Pending;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 100000, ErrorMessage = "الوزن غير صحيح")]
    [Display(Name = "الوزن الفعلي (كغ)")]
    public decimal? ActualWeight { get; set; }

    // Snapshot لسعر المادة وقت الاستلام
    [Display(Name = "نقاط لكل كيلو")]
    public int? PointsPerKgAtPickup { get; set; }

    [Display(Name = "النقاط المكتسبة")]
    public int PointsEarned { get; set; }

    [Display(Name = "تاريخ الإنجاز")]
    public DateTime? CompletedDate { get; set; }
}
