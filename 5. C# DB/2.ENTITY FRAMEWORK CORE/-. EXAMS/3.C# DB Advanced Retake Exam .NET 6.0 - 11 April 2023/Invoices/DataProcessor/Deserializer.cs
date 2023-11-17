namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Globalization;
    using System.Text;
    using CarDealer.Utilities;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new();

            ImportClientDto[] clientsDtos = new XmlHelper()
                .Deserialize<ImportClientDto[]>(xmlString, "Clients");

            ICollection<Client> validClients = new HashSet<Client>();

            foreach (ImportClientDto clientDto in clientsDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };

                foreach (var addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.Addresses.Add(new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country,
                    });
                }

                validClients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new();

            var invoicesDtos = JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString)!;

            ICollection<Invoice> validInvoices = new HashSet<Invoice>();

            int[] clientsIds = context.Clients.Select(c => c.Id).ToArray();

            foreach (ImportInvoiceDto invoiceDto in invoicesDtos)
            {
                if (!IsValid(invoiceDto)
                    || !clientsIds.Contains(invoiceDto.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime issueDate = DateTime.ParseExact(invoiceDto.IssueDate, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                DateTime dueDate = DateTime.ParseExact(invoiceDto.DueDate, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

                if (dueDate < issueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new()
                {
                    Number = invoiceDto.Number,
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = (CurrencyType)invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId
                };

                validInvoices.Add(invoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new();

            ImportProductDto[] productDtos = JsonConvert
                .DeserializeObject<ImportProductDto[]>(jsonString)!;

            int[] clientsIds = context.Clients
                .AsNoTracking()
                .Select(c => c.Id)
                .ToArray();

            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (ImportProductDto productDto in productDtos)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product product = new()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = (CategoryType)productDto.CategoryType
                };

                foreach (int clientId in productDto.Clients.Distinct())
                {
                    if(!clientsIds.Contains(clientId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    product.ProductsClients.Add(new ProductClient
                    {
                        ClientId = clientId
                    });
                }

                validProducts.Add(product);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
