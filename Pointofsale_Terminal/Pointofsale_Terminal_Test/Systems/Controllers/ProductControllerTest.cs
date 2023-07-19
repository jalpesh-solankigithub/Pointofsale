using Moq;
using Pointofsale_Terminal.Controllers;
using Pointofsale_Terminal.Interfaces;
using Pointofsale_Terminal_Test.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointofsale_Terminal_Test.Systems.Controllers
{
	public class ProductControllerTest
	{
		[Fact]
		public void ScanProducts_Shouldreturn()
		{
			//Arrange
			var productRepo = new Mock<IProductRepository>();
			var newRecord = ProductMockData.UpdateRecord();
			var sut = new ProductController(productRepo.Object);
			string productcode = "A";

			//Act
			var result = sut.SetPricing(newRecord, productcode);
			//Assert
			productRepo.Verify(_ => _.SetPricing(newRecord, productcode));
		}
	}
}
