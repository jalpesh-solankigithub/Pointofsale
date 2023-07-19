using Pointofsale_Terminal.Models;

namespace Pointofsale_Terminal.Interfaces
{
	public interface IProductRepository
	{
		//List<ProductModel> GetAll();

		int SetPricing(ProductModel productModel, string PProductCode);

		double Scan(string productCodes);

		//double CalculateTotal();
	}
}
