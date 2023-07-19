using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
	public interface IProductRepository
	{
		bool SetPricing(string productCode, double productPrice);

		double Scan(string product);

		//double CalculateTotal();

	}
}
