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
        CreateMap<Supplier, ExportSupplierDto>()
            .ForMember(d => d.PartsCount, opt => 
                opt.MapFrom(s => s.Parts.Count));

        //Parts
        CreateMap<ImportPartDto, Part>();
        CreateMap<Part, ExportPartDto>();

        //Cars
        CreateMap<ImportCarDto, Car>()
            .IgnoreAllPropertiesWithAnInaccessibleSetter();

        CreateMap<Car, ExportCarDto>();
        CreateMap<Car, ExportBMWCarDto>();
        CreateMap<Car, ExportCarWithPartsDto>()
            .ForMember(d => d.Parts, opt =>
                opt.MapFrom(s => s.PartsCars
                    .Select(pc => pc.Part)
                    .OrderByDescending(p => p.Price)
                    .ToArray()));

        //Customer
        CreateMap<ImportCustomerDto, Customer>()
            .ForMember(d => d.BirthDate, opt =>
                opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

        //Sale
        CreateMap<ImportSaleDto, Sale>();
    }
}
