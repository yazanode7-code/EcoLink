using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

[Index(nameof(BranchId), IsUnique = true)]
public class Wallet : BaseEntity
{
    [Required]
    [Display(Name = "Branch")]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Branch Branch { get; set; } = null!;

    [Display(Name = "Balance")]
    public int Balance { get; set; }

    public ICollection<WalletTransaction> Transactions { get; set; } = new List<WalletTransaction>();
}
