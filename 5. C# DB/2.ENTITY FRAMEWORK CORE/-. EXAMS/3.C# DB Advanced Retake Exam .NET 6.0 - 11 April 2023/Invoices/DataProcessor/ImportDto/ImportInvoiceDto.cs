using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto;

public class ImportInvoiceDto
{
    [Required]
    [Range(ValidationConstants.InvoiceNumberMinRange, ValidationConstants.InvoiceNumberMaxRange)]
    public int Number { get; set; }

    [Required]
    public string IssueDate { get; set; } = null!;

    [Required]
    public string DueDate { get; set;} = null!;

    [Required]
    public decimal Amount { get; set; }

    [Required]
    [Range(0, 2)]
    public int CurrencyType { get; set; }

    [Required]
    public int ClientId { get; set; }
}
