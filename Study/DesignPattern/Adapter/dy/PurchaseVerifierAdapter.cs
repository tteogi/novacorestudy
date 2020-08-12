namespace DesignPattern.Adapter.dy
{
	// old
	public class OldGooglePurchaseVerifier
	{
		private GooglePurchaseComponent _purchaseComponent = new GooglePurchaseComponent();

		public bool VerifyReceipt(GooglePurchaseComponent.GoogleReceipt receipt)
		{
			var result = _purchaseComponent.VerifyGoogle(receipt);
			return result.IsSucceed;
		}
	}
	
	// inheritance
	public class GooglePurchaseVerifier : IPurchaseVerifier
	{
		private GooglePurchaseComponent _purchaseComponent = new GooglePurchaseComponent();
		public bool VerifyReceipt(object receipt)
		{
			var googleReceipt = (GooglePurchaseComponent.GoogleReceipt)receipt;
			var result = _purchaseComponent.VerifyGoogle(googleReceipt);
			return result.IsSucceed;
		}
	}
	
	public class AppleVerifierAdapter : IPurchaseVerifier
	{
		private ApplePurchaseComponent _purchaseComponent = new ApplePurchaseComponent();
		public bool VerifyReceipt(object receipt)
		{
			var convertReceipt = (ApplePurchaseComponent.AppleReceipt)receipt;
			var result = _purchaseComponent.VerifyApple(convertReceipt).Result;
			return result.Status == 0;
		}
	}
}