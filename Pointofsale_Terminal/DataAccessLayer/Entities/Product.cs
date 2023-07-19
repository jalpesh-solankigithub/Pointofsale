using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string? ProductCode { get; set; }
		public double UnitPrice { get; set; }
		public bool IsVolumePrice { get; set; }
		public int? UnitsPerVolume { get; set; }
		public double? VolumePrice { get; set; }

	}
}
