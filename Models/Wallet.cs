using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

/// <summary>
/// محفظة نقاط الفرع — محفظة وحدة لكل فرع (One-to-One).
/// Balance مجموع جاهز، والتفاصيل بـ WalletTransactions.
/// </summary>
[Index(nameof(BranchId), IsUnique = true)]
public class Wallet : BaseEntity
{
    [Required]
    [Display(Name = "الفرع")]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Branch Branch { get; set; } = null!;

    [Display(Name = "الرصيد")]
    public int Balance { get; set; }

    public ICollection<WalletTransaction> Transactions { get; set; } = new List<WalletTransaction>();
}
