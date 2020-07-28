using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.whjeon
{
	public class Character : Goods
	{
		public DateTime Time { get; set; }

		public int Index { get; set; }

		public int Exp { get; set; }

		public int Ascend { get; set; }

		public bool IsLocked { get; set; }

		public ulong WeaponUid { get; set; }

		public override string ToString()
		{
			return "Character" + Index.ToString();
		}
	}
}
