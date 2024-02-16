#nullable disable

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Watchlist.Data.Models;
public class User : IdentityUser
{
    public User()
    {
        UsersMovies = new HashSet<UserMovie>();
    }
    //[Key]
    ////check this Prop
    //public string Id { get; set; }

    //[Required]
    //public string UserName { get; set; }

    //[Required]
    //public string Email { get; set; }

    //[Required]//check this Prop
    //public HashCode Password { get; set; }

    public virtual ICollection<UserMovie> UsersMovies { get; set; }
}


//• Has an Id – a string, Primary Key
//• Has a UserName – a string with min length 5 and max length 20 (required)
//• Has an Email – a string with min length 10 and max length 60 (required)
//• Has a Password – a string with min length 5 and max length 20 (before hashed) – no max length required
//for a hashed password in the database(required)
//• Has UsersMovies – a collection of type UserMovie