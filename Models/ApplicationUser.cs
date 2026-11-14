using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

public class ApplicationUser : IdentityUser<int>, IAuditable
{
    [Required(ErrorMessage = "Full name is required")]
    [StringLength(255)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Branch")]
    public int? BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Branch? Branch { get; set; }

    [Display(Name = "Factory")]
    public int? FactoryId { get; set; }

    [ForeignKey(nameof(FactoryId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Factory? Factory { get; set; }

    public Driver? DriverProfile { get; set; }

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Updated At")]
    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }
}
