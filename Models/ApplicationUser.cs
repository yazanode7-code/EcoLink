using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

/// <summary>
/// المستخدم — Email و PasswordHash و PhoneNumber و UserName جايين من IdentityUser.
/// الأدوار (Admin / BranchEmployee / Factory / Driver) من جداول Identity.
/// </summary>
public class ApplicationUser : IdentityUser<int>, IAuditable
{
    [Required(ErrorMessage = "الاسم مطلوب")]
    [StringLength(255)]
    [Display(Name = "الاسم الكامل")]
    public string FullName { get; set; } = string.Empty;

    // لموظف الجامعة
    [Display(Name = "الفرع")]
    public int? BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Branch? Branch { get; set; }

    // لحساب المصنع والسواقين
    [Display(Name = "المصنع")]
    public int? FactoryId { get; set; }

    [ForeignKey(nameof(FactoryId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Factory? Factory { get; set; }

    // IAuditable
    [Display(Name = "تاريخ الإنشاء")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "تاريخ التعديل")]
    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }
}
