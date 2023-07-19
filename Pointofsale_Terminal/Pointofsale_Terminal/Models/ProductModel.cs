using System.ComponentModel.DataAnnotations;

namespace Pointofsale_Terminal.Models
{
	public class ProductModel
	{
		[Key]
		public int Id { get; set; }
		public string? ProductCode { get; set; }
		public double UnitPrice { get; set; }
		public bool IsVolumePrice { get; set; }
		public int? UnitsPerVolume { get; set; }
		public double? VolumePrice { get; set; }


	}
}
