using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoLink.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EcoLink.Models;

public class FactoryProduct : BaseEntity
{
    [Required]
    [Display(Name = "Factory")]
    public int FactoryId { get; set; }

    [ForeignKey(nameof(FactoryId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Factory Factory { get; set; } = null!;

    [Required(ErrorMessage = "Product name is required")]
    [StringLength(255)]
    [Display(Name = "Product Name")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Points cost must be greater than zero")]
    [Display(Name = "Points Cost")]
    public int PointsCost { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
    [Display(Name = "Stock Quantity")]
    public int StockQuantity { get; set; }

    [Display(Name = "Active")]
    public bool IsActive { get; set; } = true;

    public ICollection<RewardOrder> RewardOrders { get; set; } = new List<RewardOrder>();
}
