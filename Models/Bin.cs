using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using EcoLink.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

[Index(nameof(QRCode), IsUnique = true)]
public class Bin : BaseEntity
{
    [Required(ErrorMessage = "Branch is required")]
    [Display(Name = "Branch")]
    public int BranchId { get; set; }

    [ForeignKey(nameof(BranchId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Branch Branch { get; set; } = null!;

    [Required(ErrorMessage = "Material type is required")]
    [Display(Name = "Material Type")]
    public int MaterialTypeId { get; set; }

    [ForeignKey(nameof(MaterialTypeId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public MaterialType MaterialType { get; set; } = null!;

    [Required(ErrorMessage = "Location is required")]
    [StringLength(500)]
    [Display(Name = "Location")]
    public string LocationDescription { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    [Display(Name = "QR Code")]
    public string QRCode { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [Display(Name = "Status")]
    public BinStatus Status { get; set; } = BinStatus.Available;

    public ICollection<PickupRequest> PickupRequests { get; set; } = new List<PickupRequest>();
}
