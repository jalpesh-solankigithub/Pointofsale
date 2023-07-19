using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointofsale_Terminal.Data;
using Pointofsale_Terminal.Interfaces;
using Pointofsale_Terminal.Models;

namespace Pointofsale_Terminal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpPost]
		[Route("ScanProducts")]
		public ActionResult<double> ScanProducts(string productCodes)
		{
		  var res=	_productRepository.Scan(productCodes.ToUpper());

			return res;
		}

		[HttpPut("SetPricing/{ProductCode}")]
		public ActionResult<int> SetPricing(ProductModel productModel, string ProductCode)
		{
			var res = _productRepository.SetPricing(productModel, ProductCode.ToUpper());

			return res;
		}

	}
}
