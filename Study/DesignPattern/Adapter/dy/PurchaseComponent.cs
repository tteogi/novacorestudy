using System.Threading.Tasks;

namespace DesignPattern.Adapter.dy
{
	// 외부 라이브러리 함수
	public class ApplePurchaseComponent
	{
		public class AppleReceipt
		{
			public int Id;
		}
		
		public class AppleResult
		{
			public int Status;
		}
		
		public Task<AppleResult> VerifyApple(AppleReceipt receipt)
		{
			return Task.FromResult(new AppleResult());
		}
	}
	
	public class GooglePurchaseComponent
	{
		public class GoogleReceipt
		{
			public string Id;
		}
		
		public class GoogleResult
		{
			public bool IsSucceed;
		}

		public GoogleResult VerifyGoogle(GoogleReceipt receipt)
		{
			return new GoogleResult();
		}
	}
}