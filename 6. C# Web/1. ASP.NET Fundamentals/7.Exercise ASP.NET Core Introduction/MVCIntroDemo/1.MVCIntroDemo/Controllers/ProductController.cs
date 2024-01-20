using _1.MVCIntroDemo.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace _1.MVCIntroDemo.Controllers;

public class ProductController : Controller
{
	private IEnumerable<ProductViewModel> products = new HashSet<ProductViewModel>()
	{
		new()
		{
			Id = 1,
			Name = "Cheese",
			Price = 7.0m
		},
		new()
		{
			Id = 2,
			Name = "Ham",
			Price = 5.5m
		},
		new()
		{
			Id = 3,
			Name = "Bread",
			Price = 1.5m
		},
	};

	//public IActionResult Index()
	//{
	//    return View();
	//}

	[Route("My-products")]
	public IActionResult All(string keyword)
	{
		if(keyword != null)
		{
			var foundProducts = products
				.Where(p => p.Name
					.ToLower()
					.Contains(keyword.ToLower()));
			products = foundProducts;
		}
		return View(products);
	}

	public IActionResult ById(int id)
	{
		var product = products
			.FirstOrDefault(p => p.Id == id);
		if (product == null)
		{
			return BadRequest();
		}

		return View(product);
	}

	public IActionResult AllAsJson()
	{
		var options = new JsonSerializerOptions
		{
			WriteIndented = true,
		};

		return Json(products, options);
	}

	public IActionResult AllAsText()
	{
		var text = String.Empty;
		foreach (var product in products)
		{
			text += $"Product {product.Id}: {product.Name} - {product.Price} lv.{Environment.NewLine}";
		}

		return Content(text);
	}

	public IActionResult AllAsTextFile()
	{
		StringBuilder sb = new();
		foreach (var product in products)
		{
			sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
		}

		Response.Headers.Add(HeaderNames.ContentDisposition, 
			@"attachmet;filename=products.txt");

		return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
	}
}
