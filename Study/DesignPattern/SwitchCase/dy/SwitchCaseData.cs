using System.Collections.Generic;

namespace DesignPattern.SwitchCase.dy
{
	public enum EnumData
	{
		GameAsset = 1,
		GameTicket,
		Weapon,
	}

	public interface IAmountAsset
	{
		int Amount { get; set; }
	}

	public class Weapon : IAmountAsset
	{
		public int Amount { get; set; }
	}

	public class Ticket : IAmountAsset
	{
		public int Amount { get; set; }
	}
	
	public class GameAsset : IAmountAsset
	{
		public int Amount { get; set; }
	}
}