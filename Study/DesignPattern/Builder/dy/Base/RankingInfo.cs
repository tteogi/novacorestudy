using System;

namespace DesignPattern.Builder.dy
{
	public class RankingInfo
	{
		public class RewardProcess
		{
			public int MinRank;
			public int MaxRank;
			public RewardProcessType RewardProcessType { get; set; }
			public RewardDeliveryType RewardDeliveryType { get; set; }
		}
		public string Name;
		public BoardType BoardType;
		public DayOfWeek SeasonEndDay;
		public RewardProcess[] RewardProcesses;
		public string[] ExcludeRewardChannelNames;
	}
}