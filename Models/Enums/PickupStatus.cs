using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Enums;

public enum PickupStatus
{
    [Display(Name = "بانتظار المراجعة")] Pending,
    [Display(Name = "تم تعيين سائق")]   Assigned,
    [Display(Name = "تم الاستلام")]     PickedUp,
    [Display(Name = "مكتمل")]          Completed,
    [Display(Name = "ملغي")]           Cancelled
}
