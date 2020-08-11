using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Adapter.whjeon
{
	public class Request 
	{
		public class CollectProduction : IAdapterReqRes
		{
			public ushort Slot { get; set; }

			public ushort GetSlot() => Slot;
		}

		public class CollectCrafting : IAdapterReqRes
		{
			public ushort Slot { get; set; }

			public ushort GetSlot() => Slot;
		}

		public class SkipCraftingTimer : IAdapterReqRes
		{
			public ushort Slot { get; set; }
			public int CurrentSkipCost { get; set; }
			public int GetSkipCost() => CurrentSkipCost;
		}

		public class SkipBuilding : IAdapterReqRes
		{
			public ushort Slot { get; set; }
			public int Cost { get; set; }
			public int GetSkipCost() => Cost;
		}
	}	
}
