using System.Diagnostics;
using System.IO;

namespace DesignPattern.Adapter.dy
{
	public class Main
	{
		public void TestMain()
		{
			// old use 
			OldGooglePurchaseVerifier oldVerifier = new OldGooglePurchaseVerifier();
			oldVerifier.VerifyReceipt(new GooglePurchaseComponent.GoogleReceipt() {Id = "11111"});

			var google = new GooglePurchaseVerifier();
			TestVerify(google, new GooglePurchaseComponent.GoogleReceipt {Id = "casefdc"});

			
			var apple = new AppleVerifierAdapter();
			TestVerify(apple, new ApplePurchaseComponent.AppleReceipt {Id = 11});
		}

		public void TestVerify(IPurchaseVerifier verifier, object receipt)
		{
			if (verifier.VerifyReceipt(receipt))
			{
				throw new InvalidDataException("");
			}
		}
	}
}