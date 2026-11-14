using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using EcoLink.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

public class RewardOrder : BaseEntity
{
    [Required]
    [Display(Name = "Branch")]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Branch Branch { get; set; } = null!;

    [Required]
    [Display(Name = "Requested By")]
    public int RequestedByEmployeeId { get; set; }

    [ForeignKey(nameof(RequestedByEmployeeId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser RequestedByEmployee { get; set; } = null!;

    [Required(ErrorMessage = "Product is required")]
    [Display(Name = "Product")]
    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public FactoryProduct Product { get; set; } = null!;

    [Required]
    [Range(1, 1000, ErrorMessage = "Invalid quantity")]
    [Display(Name = "Quantity")]
    public int Quantity { get; set; } = 1;

    [Required]
    [Display(Name = "Points Spent")]
    public int PointsSpent { get; set; }

    [Display(Name = "Driver")]
    public int? DriverId { get; set; }

    [ForeignKey(nameof(DriverId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser? Driver { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [Display(Name = "Status")]
    public RewardOrderStatus Status { get; set; } = RewardOrderStatus.Pending;

    [Display(Name = "Delivered Date")]
    public DateTime? DeliveredDate { get; set; }
}
