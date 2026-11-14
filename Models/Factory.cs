using System.ComponentModel.DataAnnotations;
using EcoLink.Models.Common;

namespace EcoLink.Models;

public class Factory : BaseEntity
{
    [Required(ErrorMessage = "Factory name is required")]
    [StringLength(255)]
    [Display(Name = "Factory Name")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "Address")]
    public string? Address { get; set; }

    [StringLength(50)]
    [Phone(ErrorMessage = "Invalid phone number")]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    public ICollection<FactoryProduct> Products { get; set; } = new List<FactoryProduct>();
    public ICollection<PickupRequest> PickupRequests { get; set; } = new List<PickupRequest>();
}
