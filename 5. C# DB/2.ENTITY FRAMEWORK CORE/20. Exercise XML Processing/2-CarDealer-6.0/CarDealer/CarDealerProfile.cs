using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        //Supplier
        CreateMap<ImportSupplierDto, Supplier>();

        //Parts
        CreateMap<ImportPartDto, Part>();

        //Cars
        CreateMap<ImportCarDto, Car>()
            .IgnoreAllPropertiesWithAnInaccessibleSetter();

    }
}
