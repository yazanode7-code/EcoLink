using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using EcoLink.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

public class PickupRequest : BaseEntity
{
    [Required]
    [Display(Name = "Bin")]
    public int BinId { get; set; }

    [ForeignKey(nameof(BinId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Bin Bin { get; set; } = null!;

    [Required]
    [Display(Name = "Reported By")]
    public int ReportedByEmployeeId { get; set; }

    [ForeignKey(nameof(ReportedByEmployeeId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser ReportedByEmployee { get; set; } = null!;

    [Display(Name = "Factory")]
    public int? FactoryId { get; set; }

    [ForeignKey(nameof(FactoryId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Factory? Factory { get; set; }

    [Display(Name = "Driver")]
    public int? DriverId { get; set; }

    [ForeignKey(nameof(DriverId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public ApplicationUser? Driver { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [Display(Name = "Status")]
    public PickupStatus Status { get; set; } = PickupStatus.Pending;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 100000, ErrorMessage = "Invalid weight")]
    [Display(Name = "Actual Weight (kg)")]
    public decimal? ActualWeight { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 100000, ErrorMessage = "Invalid weight")]
    [Display(Name = "Driver Weight (kg)")]
    public decimal? DriverWeight { get; set; }

    [Display(Name = "Points per Kg")]
    public int? PointsPerKgAtPickup { get; set; }

    [Display(Name = "Points Earned")]
    public int PointsEarned { get; set; }

    [Display(Name = "Completed Date")]
    public DateTime? CompletedDate { get; set; }
}
