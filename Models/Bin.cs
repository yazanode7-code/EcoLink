using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using EcoLink.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

/// <summary>
/// السلة العملاقة داخل الفرع.
/// </summary>
[Index(nameof(QRCode), IsUnique = true)]
public class Bin : BaseEntity
{
    [Required(ErrorMessage = "الفرع مطلوب")]
    [Display(Name = "الفرع")]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Branch Branch { get; set; } = null!;

    [Required(ErrorMessage = "نوع المادة مطلوب")]
    [Display(Name = "نوع المادة")]
    public int MaterialTypeId { get; set; }

    [ForeignKey(nameof(MaterialTypeId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public MaterialType MaterialType { get; set; } = null!;

    [Required(ErrorMessage = "وصف الموقع مطلوب")]
    [StringLength(500)]
    [Display(Name = "الموقع")]
    public string LocationDescription { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    [Display(Name = "رمز QR")]
    public string QRCode { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "nvarchar(50)")]   // بيخزن الـ enum كنص
    [Display(Name = "الحالة")]
    public BinStatus Status { get; set; } = BinStatus.Available;

    public ICollection<PickupRequest> PickupRequests { get; set; } = new List<PickupRequest>();
}
