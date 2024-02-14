using Microsoft.AspNetCore.Http;

namespace SoftUniBazar.Common;

public static class ErrorMessages
{
    public const string RequiredField = "The field {0} is required";
    public const string RequiredLength = "The field {0} length must be between {2} and {1} charachters";
    //public const string RequiredPriceRange = "{0} range must be between {2} and {1}";

    public const string WrongCategory = "Category does not exist";
}
