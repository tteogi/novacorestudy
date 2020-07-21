using System.Diagnostics;

namespace DesignPattern.SwitchCase.dy
{
	public class TestClass
	{
		public EnumData EnumData;
		public int Value;
		public IAmountAsset Asset;
	}
	
	public class SwitchCaseMain
	{
		public void TestMain()
		{
			var testClasses = new TestClass[]
			{
				new TestClass() {EnumData = EnumData.Weapon, Asset = new Weapon()},
				new TestClass() {EnumData = EnumData.GameTicket, Asset = new Ticket()},
				new TestClass() {EnumData = EnumData.GameAsset, Asset = new GameAsset()},
			};

			for (var i = 0; i < testClasses.Length; i++)
			{
				TestClass testClass = testClasses[i];
				var command = EnumCommand.Commands[testClass.EnumData];
				command.RefCommand(ref testClass.Value, i);
				
				
				var obj = command.ReturnObject();
				Debug.Assert(obj is Weapon);

				command.SetAmountCommand(testClass.Asset, i);
				command.SetAmountCommandByObject(testClass.Asset, i);
			}
		}
	}
}