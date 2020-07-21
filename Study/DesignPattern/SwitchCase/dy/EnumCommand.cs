using System;
using System.Collections.Generic;

namespace DesignPattern.SwitchCase.dy
{
	public class EnumCommand
	{
		public static Dictionary<EnumData, EnumCommand> Commands = new Dictionary<EnumData, EnumCommand>()
		{
			{
				EnumData.GameAsset, new EnumCommand()
				{
					RefCommand = (ref int data, int value) =>
					{
						if (data <= 0)
							throw new ArgumentOutOfRangeException(nameof(data));
						data = value;
					},
					SetAmountCommand = (asset, i) => { asset.Amount = i; },
					SetAmountCommandByObject = (o, i) =>
					{
						var amountObject = (GameAsset) o;
						amountObject.Amount = i;
					},
					ReturnObject = () => new GameAsset()
				}
			},
			{
				EnumData.GameTicket, new EnumCommand()
				{
					RefCommand = (ref int data, int value) =>
					{
						data = value;
					},
					SetAmountCommand = (asset, i) => { asset.Amount = i; },
					SetAmountCommandByObject = (o, i) =>
					{
						var amountObject = (Ticket) o;
						amountObject.Amount = i;
					},
					ReturnObject = () => new Ticket()
				}
			},
			{
				EnumData.GameAsset, new EnumCommand()
				{
					RefCommand = (ref int data, int value) => { data = value; },
					SetAmountCommand = (asset, i) => { asset.Amount = i; },
					SetAmountCommandByObject = (o, i) =>
					{
						var amountObject = (Weapon) o;
						amountObject.Amount = i;
					},
					ReturnObject = () => new Weapon()
				}
			}
		};

		static EnumCommand()
		{
			System.Diagnostics.Debug.Assert(Commands.Count == Enum.GetValues(typeof(EnumData)).Length,
				"EnumCommand does not have EnumData type");
		}


		public delegate void ActionRef(ref int setData, int value);

		public ActionRef RefCommand;
		public Action<IAmountAsset, int> SetAmountCommand;
		public Action<object, int> SetAmountCommandByObject;
		public Func<object> ReturnObject;
	}
}