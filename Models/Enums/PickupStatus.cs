using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Enums;

public enum PickupStatus
{
    [Display(Name = "Pending")] Pending,
    [Display(Name = "Driver Assigned")] Assigned,
    [Display(Name = "Awaiting Confirmation")] Collected,
    [Display(Name = "Completed")] Completed,
    [Display(Name = "Cancelled")] Cancelled
}
