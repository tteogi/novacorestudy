using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Factory.dy
{
	using System;
	using System.Collections.Generic;

	namespace ServerCommon.EosRpg
	{
		public enum GoodsType
		{
			Character,
			Weapon,
			Box,
		}

		public class Goods
		{
			public GoodsType Type;
			public int Value1;
			public int Value2;
			public readonly Func<Goods, string> Formatter;

			public Goods(GoodsType type, Func<Goods, string> formatter, int value1)
			{
				Type = type;
				Formatter = formatter;
				Value1 = value1;
			}

			public Goods(GoodsType type, Func<Goods, string> formatter, int value1, int value2)
			{
				Type = type;
				Formatter = formatter;
				Value1 = value1;
				Value2 = value2;
			}

			public override string ToString()
			{
				return Formatter(this);
			}
		}

		public class Factory<TKey, TArg1, Result>
		{
			private readonly Dictionary<TKey, Func<TArg1, Result>> _dict = new Dictionary<TKey, Func<TArg1, Result>>();

			public Result Create(TKey type, TArg1 arg1)
			{
				return _dict[type](arg1);
			}

			public void Register(TKey type, Func<TArg1, Result> factoryMethod)
			{
				_dict[type] = factoryMethod;
			}
		}

		public class Factory<TKey, TArg1, TArg2, Resultt>
		{
			private readonly Dictionary<TKey, Func<TArg1, TArg2, Resultt>> _dict =
				new Dictionary<TKey, Func<TArg1, TArg2, Resultt>>();

			public Resultt Create(TKey type, TArg1 arg1, TArg2 arg2)
			{
				return _dict[type](arg1, arg2);
			}

			public void Register(TKey type, Func<TArg1, TArg2, Resultt> factoryMethod)
			{
				_dict[type] = factoryMethod;
			}
		}

		public class GoodsFactory
		{
			static Factory<GoodsType, int, Goods> _factory1Arg = new Factory<GoodsType, int, Goods>();
			static Factory<GoodsType, int, int, Goods> _factory2Arg = new Factory<GoodsType, int, int, Goods>();

			static GoodsFactory()
			{
				Register(GoodsType.Character, (g) => $"A:{g.Value1}");
				Register(GoodsType.Weapon, (g) => $"T:{g.Value1}:{g.Value2}");
				Register(GoodsType.Box, (g) => $"B:{g.Value1}");
			}

			public static Goods Create(GoodsType type, int arg1)
			{
				return _factory1Arg.Create(type, arg1);
			}

			public static Goods Create(GoodsType type, int arg1, int arg2)
			{
				return _factory2Arg.Create(type, arg1, arg2);
			}

			private static void Register(GoodsType type, Func<Goods, string> formatter)
			{
				RegisterArg1(type, formatter);
				RegisterArg2(type, formatter);
			}

			private static void RegisterArg1(GoodsType type, Func<Goods, string> formatter)
			{
				_factory1Arg.Register(type, arg1 => new Goods(type, formatter, arg1));
			}

			private static void RegisterArg2(GoodsType type, Func<Goods, string> formatter)
			{
				_factory2Arg.Register(type, (arg1, arg2) => new Goods(type, formatter, arg1, arg2));
			}
		}

		public class Test
		{
			public void Main()
			{
				var goods = GoodsFactory.Create(GoodsType.Character, 1);
				goods = GoodsFactory.Create(GoodsType.Box, 1);
				goods = GoodsFactory.Create(GoodsType.Weapon, 1, 2);
			}
		}
	}

}
