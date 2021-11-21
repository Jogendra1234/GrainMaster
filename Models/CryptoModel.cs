using System;

namespace GrainMaster.Models
{
    public class CryptoModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal TotalBuyPrice { get; set; }
		public decimal TotalSellPrice { get; set; }
		public DateTime Date { get; set; }
		public decimal CurrentPrice { get; set; }
	}
}
