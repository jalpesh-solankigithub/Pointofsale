using Pointofsale_Terminal.Data;
using Pointofsale_Terminal.Models;

namespace Pointofsale_Terminal.Interfaces
{
	public class ProductRepository : IProductRepository
	{
		private readonly Pointofsale_TerminalContext _context;

		public ProductRepository(Pointofsale_TerminalContext context)
		{
			_context = context;
		}

		public ProductModel GetByProductCode(string productCode)
		{
			var productdetails = _context.ProductModel.Where(a => a.ProductCode == productCode).FirstOrDefault();
			if(productdetails!=null)
				return productdetails;
			return new ProductModel();
		}

		public double Scan(string productCodes)
		{
			List<ProductModel> Products = new List<ProductModel>();
			char[] chars = productCodes.ToCharArray();
			
			if (chars.Length == 0)
				return 0;

			else if (chars.Length == 1)
			{
				var prdetails = GetByProductCode(productCodes.ToString());
				return prdetails.UnitPrice;
			}
			else
			{
				foreach (var ch in chars)
				{
					var prdetails = GetByProductCode(ch.ToString());
					Products.Add(prdetails);
				}

				double price = CalculateTotalPrice(productCodes, Products);

				return price;
			}
		}
		
		public double CalculateTotalPrice(string productCodes, List<ProductModel> Products)
		{
			double totalPrice = 0.0;

			// Create a dictionary to store the count of each product code in the shopping cart
			Dictionary<string, int> productCount = new Dictionary<string, int>();

			foreach (char productCode in productCodes)
			{
				if (productCount.ContainsKey(productCode.ToString()))
				{
					productCount[productCode.ToString()]++;
				}
				else
				{
					productCount[productCode.ToString()] = 1;
				}
			}

			// Calculate the total price based on the unit prices and volume prices
			foreach (var entry in productCount)
			{
				string productCode = entry.Key;
				int count = entry.Value;

				// Find the product in the list of products by product code
				ProductModel product = Products.Where(p => p.ProductCode == productCode).FirstOrDefault();

				if (product != null)
				{
					if (product.IsVolumePrice && product.UnitsPerVolume.HasValue && product.VolumePrice.HasValue)
					{
						// Calculate the total price based on the volume price
						int volumeCount = count / product.UnitsPerVolume.Value;
						int remainderCount = count % product.UnitsPerVolume.Value;

						totalPrice += volumeCount * product.VolumePrice.Value;
						totalPrice += remainderCount * product.UnitPrice;
					}
					else
					{
						// Calculate the total price based on the unit price
						totalPrice += count * product.UnitPrice;
					}
				}
			}

			return totalPrice;
		}


		public int SetPricing(ProductModel productModel, string ProductCode)
		{
			var prod = _context.ProductModel.Where(x => x.ProductCode == ProductCode).FirstOrDefault();

			if (prod != null)
			{
				prod.UnitPrice = productModel.UnitPrice;
				prod.IsVolumePrice = productModel.IsVolumePrice;
				prod.UnitsPerVolume = productModel.UnitsPerVolume;
				prod.VolumePrice = productModel.VolumePrice;

						 _context.Update(prod);
				var res=_context.SaveChanges();

				return res;
			}
			return 0;
		}
	}
}
