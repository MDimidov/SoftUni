using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto;


public class ImportTicketDto
{
    [Required]
    [Range(ValidationConstants.TicketPriceMinRange, ValidationConstants.TicketPriceMaxRange)]
    public decimal Price { get; set; }

    [Required]
    [Range(ValidationConstants.TicketRowNumberMinRange, ValidationConstants.TicketRowNumberMaxRange)]
    public sbyte RowNumber { get; set; }

    [Required]
    public int PlayId { get; set; }
}
