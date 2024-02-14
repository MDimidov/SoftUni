#nullable disable

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models;

public class AdBuyer
{
    [ForeignKey(nameof(Buyer))]
    public string BuyerId { get; set; }

    public virtual IdentityUser Buyer { get; set; }


    [ForeignKey(nameof(Ad))]
    public int AdId { get; set; }

    public virtual Ad Ad { get; set; }
}

//BuyerId – a string, Primary Key, foreign key(required)
//• Buyer – IdentityUser
//• AdId – an integer, Primary Key, foreign key(required)
//• Ad – Ad
