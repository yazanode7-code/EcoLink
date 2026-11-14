using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using EcoLink.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

public class WalletTransaction : BaseEntity
{
    [Required]
    public int WalletId { get; set; }

    [ForeignKey(nameof(WalletId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Wallet Wallet { get; set; } = null!;

    [Required]
    [Display(Name = "Amount")]
    public int Amount { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [Display(Name = "Type")]
    public WalletTransactionType Type { get; set; }

    public int? PickupRequestId { get; set; }

    [ForeignKey(nameof(PickupRequestId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public PickupRequest? PickupRequest { get; set; }

    public int? RewardOrderId { get; set; }

    [ForeignKey(nameof(RewardOrderId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public RewardOrder? RewardOrder { get; set; }
}
