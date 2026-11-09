using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using EcoLink.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

/// <summary>
/// سجل حركات المحفظة — موجب = إضافة، سالب = خصم.
/// </summary>
public class WalletTransaction : BaseEntity
{
    [Required]
    public int WalletId { get; set; }

    [ForeignKey(nameof(WalletId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Wallet Wallet { get; set; } = null!;

    [Required]
    [Display(Name = "عدد النقاط")]
    public int Amount { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]   // بيخزن الـ enum كنص
    [Display(Name = "نوع الحركة")]
    public WalletTransactionType Type { get; set; }

    // إذا الحركة جاية من تسليم مواد
    public int? PickupRequestId { get; set; }

    [ForeignKey(nameof(PickupRequestId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public PickupRequest? PickupRequest { get; set; }

    // إذا الحركة راحت على مكافأة
    public int? RewardOrderId { get; set; }

    [ForeignKey(nameof(RewardOrderId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public RewardOrder? RewardOrder { get; set; }
}
