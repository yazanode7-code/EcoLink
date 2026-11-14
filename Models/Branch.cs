using System.ComponentModel.DataAnnotations;
using EcoLink.Models.Common;

namespace EcoLink.Models;

public class Branch : BaseEntity
{
    [Required(ErrorMessage = "Branch name is required")]
    [StringLength(255)]
    [Display(Name = "Branch Name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "Address")]
    public string? Address { get; set; }

    public Wallet? Wallet { get; set; }

    public ICollection<ApplicationUser> Employees { get; set; } = new List<ApplicationUser>();
    public ICollection<Bin> Bins { get; set; } = new List<Bin>();
    public ICollection<RewardOrder> RewardOrders { get; set; } = new List<RewardOrder>();
}
