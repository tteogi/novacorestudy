using System.Threading.Tasks;

namespace DesignPattern.Builder.dy
{
	public abstract class RewardProcess : IRewardProcess
	{
		public IRewardDelivery DeliveryMethod { get; protected set; }
		public abstract Task DoRewardAsync();
		public abstract Task StartNewSeason();
		
		public class Builder<T, TProcess> where T : Builder<T, TProcess> where TProcess : RewardProcess, new()
		{
			protected TProcess _rewardProcess;
			
			public Builder()
			{
				_rewardProcess = new TProcess();
			}
			
			public T UseMailDelivery()
			{
				_rewardProcess.DeliveryMethod = new MailDelivery();
				return (T)this;
			}
			
			public T UseDirectDelivery()
			{
				_rewardProcess.DeliveryMethod = new DirectDelivery();
				return (T)this;
			}

			public TProcess Build()
			{
				return _rewardProcess;
			}
		}
	}
	
	public class FixRewardProcess : RewardProcess
	{
		private int _minRank;
		private int _maxRank;

		public override async Task DoRewardAsync()
		{
			throw new System.NotImplementedException();
		}

		public override async Task StartNewSeason()
		{
			throw new System.NotImplementedException();
		}

		public class Builder : Builder<Builder, FixRewardProcess>
		{
			public Builder SetMinRank(int rank)
			{
				_rewardProcess._minRank = rank;
				return this;
			}
			
			public Builder SetMaxRank(int rank)
			{
				_rewardProcess._maxRank = rank;
				return this;
			}
		}
	}

	public class PercentageRewardProcess : RewardProcess
	{
		private int _excludeMinRank;

		public override async Task DoRewardAsync()
		{
			throw new System.NotImplementedException();
		}

		public override async Task StartNewSeason()
		{
			throw new System.NotImplementedException();
		}
		
		public class Builder : Builder<Builder, PercentageRewardProcess>
		{
			public Builder SetExcludeMinRank(int rank)
			{
				_rewardProcess._excludeMinRank = rank;
				return this;
			}
		}
	}
}