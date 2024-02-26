#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Common.EntityValidationConstants.House;

namespace HouseRentingSystem.Data.Models;

public class House
{
    //public House()
    //{
    //    Id = Guid.NewGuid();
    //}

    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; }

    [Required]
    [MaxLength(AddressMaxLength)]
    public string Address { get; set; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; }

    [Required]
    [MaxLength(ImageUrlMaxLength)]
    public string ImageUrl { get; set; }

    [Required]
    public decimal PricePerMonth { get; set; }

    [Required]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }


    [Required]
    [ForeignKey(nameof(Agent))]
    public Guid AgentId { get; set; }

    public virtual Agent Agent { get; set; }

    [ForeignKey(nameof(Renter))]
    public Guid? RenterId { get; set; }

    public virtual ApplicationUser Renter { get; set; }
}
