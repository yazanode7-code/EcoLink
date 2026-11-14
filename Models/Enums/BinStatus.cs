using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Enums;

public enum BinStatus
{
    [Display(Name = "Available")] Available,
    [Display(Name = "Full")] Full,
    [Display(Name = "Pickup Requested")] PickupRequested,
    [Display(Name = "Out of Service")] OutOfService
}
