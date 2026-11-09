namespace EcoLink.Models.Common;

/// <summary>
/// الأعمدة المشتركة لكل الجداول (التواريخ + الحذف المنطقي).
/// ApplicationUser بيطبقه مباشرة لأنه بيورث من IdentityUser.
/// </summary>
public interface IAuditable
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    bool IsDeleted { get; set; }
}
