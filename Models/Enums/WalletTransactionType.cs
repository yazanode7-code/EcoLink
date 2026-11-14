using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Enums;

public enum WalletTransactionType
{
    [Display(Name = "Earned")] Earned,
    [Display(Name = "Spent")] Spent,
    [Display(Name = "Refund")] Refund
}
