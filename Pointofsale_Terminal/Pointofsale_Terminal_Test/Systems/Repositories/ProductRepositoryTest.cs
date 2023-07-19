using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pointofsale_Terminal.Controllers;
using Pointofsale_Terminal.Data;
using Pointofsale_Terminal.Interfaces;
using Pointofsale_Terminal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointofsale_Terminal_Test.Systems.Repositories
{
	public class ProductRepositoryTest
	{
		private readonly Pointofsale_TerminalContext _dbContext, context;

		public ProductRepositoryTest()
		{
			var _options = new DbContextOptionsBuilder<Pointofsale_TerminalContext>()

			  .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
			  .Options;
			  _dbContext = new Pointofsale_TerminalContext(_options);
			_dbContext.Database.EnsureCreated();
			context = new Pointofsale_TerminalContext(_options);

		}

		[Fact]
		public void ScanProducts_Shouldreturn1()
		{

			// Add dummy data to the in-memory database

			context.ProductModel.Add(new ProductModel { Id = 1, ProductCode = "A", UnitPrice = 1.25, IsVolumePrice = true, UnitsPerVolume = 3, VolumePrice = 3 });
			context.ProductModel.Add(new ProductModel { Id = 2, ProductCode = "B", UnitPrice = 4.25, IsVolumePrice = false, UnitsPerVolume = null, VolumePrice = null });
			context.ProductModel.Add(new ProductModel { Id = 3, ProductCode = "C", UnitPrice = 1, IsVolumePrice = true, UnitsPerVolume = 6, VolumePrice = 5 });
			context.ProductModel.Add(new ProductModel { Id = 4, ProductCode = "D", UnitPrice = 0.75, IsVolumePrice = false, UnitsPerVolume = null, VolumePrice = null });

			context.SaveChanges();

			string input = "ABCDABA";
			double expected = 13.25;
			IProductRepository productRepository = new ProductRepository(context);

			ProductController productController = new ProductController(productRepository);

			var res = productController.ScanProducts(input);
			Assert.Equal(expected, res.Value);

		}

		[Fact]
		public void ScanProducts_Shouldreturn2()
		{
			// Add dummy data to the in-memory database

			context.ProductModel.Add(new ProductModel { Id = 5, ProductCode = "A", UnitPrice = 1.25, IsVolumePrice = true, UnitsPerVolume = 3, VolumePrice = 3 });
			context.ProductModel.Add(new ProductModel { Id = 6, ProductCode = "B", UnitPrice = 4.25, IsVolumePrice = false, UnitsPerVolume = null, VolumePrice = null });
			context.ProductModel.Add(new ProductModel { Id = 7, ProductCode = "C", UnitPrice = 1, IsVolumePrice = true, UnitsPerVolume = 6, VolumePrice = 5 });
			context.ProductModel.Add(new ProductModel { Id = 8, ProductCode = "D", UnitPrice = 0.75, IsVolumePrice = false, UnitsPerVolume = null, VolumePrice = null });

			context.SaveChanges();

			string input = "CCCCCCC";
			double expected = 6.00;
			IProductRepository productRepository = new ProductRepository(context);

			ProductController productController = new ProductController(productRepository);

			var res = productController.ScanProducts(input);
			Assert.Equal(expected, res.Value);

		}
		[Fact]
		public void ScanProducts_Shouldreturn3()
		{
			// Add dummy data to the in-memory database

			context.ProductModel.Add(new ProductModel { Id = 9, ProductCode = "A", UnitPrice = 1.25, IsVolumePrice = true, UnitsPerVolume = 3, VolumePrice = 3 });
			context.ProductModel.Add(new ProductModel { Id = 10, ProductCode = "B", UnitPrice = 4.25, IsVolumePrice = false, UnitsPerVolume = null, VolumePrice = null });
			context.ProductModel.Add(new ProductModel { Id = 11, ProductCode = "C", UnitPrice = 1, IsVolumePrice = true, UnitsPerVolume = 6, VolumePrice = 5 });
			context.ProductModel.Add(new ProductModel { Id = 12, ProductCode = "D", UnitPrice = 0.75, IsVolumePrice = false, UnitsPerVolume = null, VolumePrice = null });

			context.SaveChanges();

			string input = "ABCD";
			double expected = 7.25;
			IProductRepository productRepository = new ProductRepository(context);

			ProductController productController = new ProductController(productRepository);

			var res = productController.ScanProducts(input);
			Assert.Equal(expected, res.Value);

		}
		public void Dispose()
		{
			_dbContext.Database.EnsureDeleted();
			_dbContext.Dispose();
		}	
	}
}
