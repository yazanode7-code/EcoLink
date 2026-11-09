using System.ComponentModel.DataAnnotations;

namespace EcoLink.Models.Common;

/// <summary>
/// الكلاس الأب لكل الجداول (ما عدا ApplicationUser).
/// ما بيصير جدول لحاله — لا تعمل DbSet&lt;BaseEntity&gt;.
/// </summary>
public abstract class BaseEntity : IAuditable
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "تاريخ الإنشاء")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "تاريخ التعديل")]
    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }
}
