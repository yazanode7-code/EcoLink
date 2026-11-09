using System.ComponentModel.DataAnnotations;
using EcoLink.Models.Common;

namespace EcoLink.Models;

/// <summary>
/// مصنع إعادة التدوير — إله حساب واحد + سواقين (كلهم ApplicationUser بـ FactoryId).
/// </summary>
public class Factory : BaseEntity
{
    [Required(ErrorMessage = "اسم المصنع مطلوب")]
    [StringLength(255)]
    [Display(Name = "اسم المصنع")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "العنوان")]
    public string? Address { get; set; }

    [StringLength(50)]
    [Phone(ErrorMessage = "رقم الهاتف غير صحيح")]
    [Display(Name = "رقم الهاتف")]
    public string? PhoneNumber { get; set; }

    // حساب المصنع + السواقين
    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    public ICollection<FactoryProduct> Products { get; set; } = new List<FactoryProduct>();
    public ICollection<PickupRequest> PickupRequests { get; set; } = new List<PickupRequest>();
}
