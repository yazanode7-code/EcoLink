using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

[Index(nameof(UserId), IsUnique = true)]
[Index(nameof(LicenseNumber), IsUnique = true)]
[Index(nameof(VehiclePlate), IsUnique = true)]
public class Driver : BaseEntity
{
    [Required]
    [Display(Name = "User")]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser User { get; set; } = null!;

    [Required(ErrorMessage = "License number is required")]
    [StringLength(50)]
    [Display(Name = "License Number")]
    public string LicenseNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vehicle plate is required")]
    [StringLength(20)]
    [Display(Name = "Vehicle Plate")]
    public string VehiclePlate { get; set; } = string.Empty;

    [Display(Name = "Available")]
    public bool IsAvailable { get; set; } = true;
}
