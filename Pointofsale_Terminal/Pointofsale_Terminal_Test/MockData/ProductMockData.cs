using Pointofsale_Terminal.Data;
using Pointofsale_Terminal.Interfaces;
using Pointofsale_Terminal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointofsale_Terminal_Test.MockData
{
	public class ProductMockData
	{
		public static ProductModel UpdateRecord()
		{
			return new ProductModel
			{
				ProductCode ="E",
				UnitPrice =10,
				IsVolumePrice=true,
				UnitsPerVolume=12,
				VolumePrice=100			
			};
		}
	}
}
