using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Common;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models;

public class Truck
{
    public Truck()
    {
        ClientsTrucks = new HashSet<ClientTruck>();
    }

    [Key]
    public int Id { get; set; }

    [StringLength(ValidationConstants.TruckRegistrationNumberLength)]
    public string RegistrationNumber { get; set; } = null!;

    [StringLength(ValidationConstants.TruckVinNumberLength)]
    public string VinNumber { get; set; } = null!;

    [Range(ValidationConstants.TruckTankCapacityMinRange, ValidationConstants.TruckTankCapacityMaxRange)]
    public int? TankCapacity { get; set; }

    [Range(ValidationConstants.TruckCargoCapacityMinRange, ValidationConstants.TruckCargoCapacityMaxRange)]
    public int? CargoCapacity { get; set; }

    public CategoryType CategoryType { get; set; }

    public MakeType MakeType { get; set; }

    [ForeignKey(nameof(Despatcher))]
    public int DespatcherId { get; set; }

    public virtual Despatcher Despatcher { get; set; } = null!;
     
    public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
}
