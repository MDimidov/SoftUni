using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Data.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {

    }

    public virtual ICollection<House> Houses { get; set; } = new HashSet<House>();
}
