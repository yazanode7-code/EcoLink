using System.ComponentModel.DataAnnotations;
using EcoLink.Models.Common;

namespace EcoLink.Models;

/// <summary>
/// فرع من فروع جامعة البلقاء التطبيقية.
/// </summary>
public class Branch : BaseEntity
{
    [Required(ErrorMessage = "اسم الفرع مطلوب")]
    [StringLength(255)]
    [Display(Name = "اسم الفرع")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "العنوان")]
    public string? Address { get; set; }

    public Wallet? Wallet { get; set; }

    public ICollection<ApplicationUser> Employees { get; set; } = new List<ApplicationUser>();
    public ICollection<Bin> Bins { get; set; } = new List<Bin>();
    public ICollection<RewardOrder> RewardOrders { get; set; } = new List<RewardOrder>();
}
