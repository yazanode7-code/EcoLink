using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Enums;

public enum WalletTransactionType
{
    [Display(Name = "نقاط مكتسبة")] Earned,
    [Display(Name = "نقاط مصروفة")] Spent,
    [Display(Name = "نقاط مستردة")] Refund
}
