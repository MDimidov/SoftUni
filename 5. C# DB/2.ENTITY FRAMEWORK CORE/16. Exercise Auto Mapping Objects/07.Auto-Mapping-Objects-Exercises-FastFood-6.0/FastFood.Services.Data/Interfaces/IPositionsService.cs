﻿using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Positions;

namespace FastFood.Services.Data.Interfaces;

public interface IPositionsService
{
    Task CreateAsync(CreatePositionInputModel inputModel);
    Task<IEnumerable<PositionsAllViewModel>> GetAllAsync();
}
