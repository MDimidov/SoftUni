namespace Invoices.Common;

public static class ValidationConstants
{
    //Product
    public const int ProductNameMinLength = 9;
    public const int ProductNameMaxLength = 30;
    public const double ProductPriceMinRange = 5.0;
    public const double ProductPriceMaxRange = 1_000.0;
    public const int ProductCategoryTypeMaxRange = 4;

    //Address
    public const int AddressStreetNameMinLength = 10;
    public const int AddressStreetNameMaxLength = 20;
    public const int AddressCityMinLength = 5;
    public const int AddressCityMaxLength = 15;
    public const int AddressCountryMinLength = 5;
    public const int AddressCountryMaxLength = 15;

    //Invoice
    public const int InvoiceNumberMinRange = 1_000_000_000;
    public const int InvoiceNumberMaxRange = 1_500_000_000;
    public const int InvoiceCurrencyTypeMaxRange = 2;

    //Client
    public const int ClientNameMinLength = 10;
    public const int ClientNameMaxLength = 25;
    public const int ClientNumberVatMinLength = 10;
    public const int ClientNumberVatMaxLength = 15;
}
