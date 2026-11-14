using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Enums;

public enum RewardOrderStatus
{
    [Display(Name = "Pending")] Pending,
    [Display(Name = "Approved")] Approved,
    [Display(Name = "Out for Delivery")] OutForDelivery,
    [Display(Name = "Delivered")] Delivered,
    [Display(Name = "Rejected")] Rejected
}
