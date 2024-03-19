#nullable disable

using HouseRentingSystem.Web.ViewModels.Category.Interfaces;

namespace HouseRentingSystem.Web.ViewModels.Category;

public class CategoryDetailsViewModel : ICategoryDetailsModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}
