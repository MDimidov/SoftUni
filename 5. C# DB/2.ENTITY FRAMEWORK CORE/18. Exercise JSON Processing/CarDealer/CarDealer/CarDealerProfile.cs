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

        //Part
        CreateMap<ImportPartDto, Part>();

        //Car
        CreateMap<ImportCarDto, Car>()
            .IgnoreAllPropertiesWithAnInaccessibleSetter();

        //Customer
        CreateMap<ImportCustomerDto, Customer>();

        //Sale
        CreateMap<ImportSaleDto, Sale>();
    }
}
