using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;

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

        CreateMap<Car, ExportCarDto>();
        CreateMap<Car, ExportBMWCarDto>();

        //Customer
        CreateMap<ImportCustomerDto, Customer>()
            .ForMember(d => d.BirthDate, opt =>
                opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

        //Sale
        CreateMap<ImportSaleDto, Sale>();
    }
}
