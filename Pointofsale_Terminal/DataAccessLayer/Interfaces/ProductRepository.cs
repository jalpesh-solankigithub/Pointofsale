using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public ProductRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public double Scan(string product)
		{
			throw new NotImplementedException();
		}

		public bool SetPricing(string productCode, double productPrice)
		{
			throw new NotImplementedException();
		}
	}
}
