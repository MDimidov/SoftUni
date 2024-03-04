using System.Security.Claims;

namespace HouseRentingSystem.Web.Infrastructure.Extensions;

public static class ClaimsPrincipalsExtensions
{
	public static string? GetId(this ClaimsPrincipal user)
		=> user.FindFirstValue(ClaimTypes.NameIdentifier);


}
