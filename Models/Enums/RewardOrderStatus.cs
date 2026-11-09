using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Enums;

public enum RewardOrderStatus
{
    [Display(Name = "بانتظار الموافقة")] Pending,
    [Display(Name = "تمت الموافقة")]    Approved,
    [Display(Name = "قيد التوصيل")]     OutForDelivery,
    [Display(Name = "تم التسليم")]      Delivered,
    [Display(Name = "مرفوض")]          Rejected
}
