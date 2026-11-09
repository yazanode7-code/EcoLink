using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Enums;

public enum BinStatus
{
    [Display(Name = "متاحة")]          Available,
    [Display(Name = "ممتلئة")]         Full,
    [Display(Name = "بانتظار التفريغ")] PickupRequested,
    [Display(Name = "خارج الخدمة")]    OutOfService
}
