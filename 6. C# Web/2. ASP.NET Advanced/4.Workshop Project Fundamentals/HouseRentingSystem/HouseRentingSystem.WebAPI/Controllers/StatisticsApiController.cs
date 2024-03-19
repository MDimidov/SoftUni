using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Services.Data.Models.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.WebAPI.Controllers
{
	//Change after to api/statistics
	[Route("api/statistics")]
	[ApiController]
	public class StatisticsApiController : ControllerBase
	{
		private readonly IHouseService houseService;
		
		public StatisticsApiController(IHouseService houseService)
		{
			this.houseService = houseService;
		}


		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetStatistics()
		{
			try
			{
				StatisticsServiceModel serviceModel = await houseService.GetStatisticsAsync();

				return Ok(serviceModel);
			}
			catch
			{
				return BadRequest(); 
			}
		}
	}
}
