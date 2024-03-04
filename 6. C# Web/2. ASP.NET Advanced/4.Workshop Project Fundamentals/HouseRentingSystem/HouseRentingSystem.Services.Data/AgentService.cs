﻿using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Agent;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data;

public class AgentService : IAgentService
{
	private readonly HouseRentingDbContext dbContext;

	public AgentService(HouseRentingDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task<bool> AgentExistByUserIdAsync(string userId)
		=> await dbContext
			.Agents
			.AnyAsync(a => a.UserId.ToString() == userId);

	public async Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber)
		=> await dbContext
			.Agents
			.AnyAsync(a => a.PhoneNumber == phoneNumber);

	public async Task Create(string userId, BecomeAgentFormModel model)
	{
		Agent agent = new()
		{
			PhoneNumber = model.PhoneNumber,
			UserId = Guid.Parse(userId),
		};

		await dbContext.Agents.AddAsync(agent);
		await dbContext.SaveChangesAsync();
	}

	public async Task<bool> HasRentsByUserIdAsync(string userId)
	{
		ApplicationUser? user = await dbContext
			.Users
			.FindAsync(Guid.Parse(userId));

		if (user == null)
		{
			return false;
		}

		return user.Houses.Any();
	}
}
