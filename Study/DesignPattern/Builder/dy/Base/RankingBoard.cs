using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern.Builder.dy
{
	public abstract class RankingBoard : IRankingBoard
	{
		public string Name { get; private set; }
		public List<IRewardProcess> RewardProcess { get; private set; }
		public string[] ExcludeRewardChannels { get; private set; }
	
		public async Task Update()
		{
			foreach (var rewardProcess in RewardProcess)
			{
				await rewardProcess.DoRewardAsync();
			}
	
			foreach (var rewardProcess in RewardProcess)
			{
				await rewardProcess.StartNewSeason();
			}
		}
	
		public class Builder
		{
			protected RankingBoard RankingBoard;
	
			public Builder(BoardType type)
			{
				switch (type)
				{
					case BoardType.Daily:
						RankingBoard = new DailyRankingBoard();
						break;
					case BoardType.Weekly:
						RankingBoard = new WeeklyRankingBoard();
						break;
					case BoardType.Monthly:
						RankingBoard = new MonthlyRankingBoard();
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(type), type, null);
				}
			}
	
			public RankingBoard Build()
			{
				return RankingBoard;
			}
	
			public Builder SetName(string name)
			{
				RankingBoard.Name = name;
				return this;
			}
	
			public Builder SetExcludeRewardChannels(string[] excludeRewardChannels)
			{
				RankingBoard.ExcludeRewardChannels = excludeRewardChannels;
				return this;
			}
	
			public Builder SetSeasonEndDay(DayOfWeek dayOfWeek)
			{
				if (RankingBoard is MultipleDaysRankingBoard multipleDays)
					multipleDays.SeasonEndDay = dayOfWeek;
				return this;
			}
	
			public Builder AddFixRewardProcess(Action<FixRewardProcess.Builder> builderMethod)
			{
				if (RankingBoard.RewardProcess == null)
					RankingBoard.RewardProcess = new List<IRewardProcess>();
	
				var builder = new FixRewardProcess.Builder();
				builderMethod(builder);
	
				RankingBoard.RewardProcess.Add(builder.Build());
				return this;
			}
	
			public Builder AddPercentageRewardProcess(Action<PercentageRewardProcess.Builder> builderMethod)
			{
				if (RankingBoard.RewardProcess == null)
					RankingBoard.RewardProcess = new List<IRewardProcess>();
	
				var builder = new PercentageRewardProcess.Builder();
				builderMethod(builder);
	
				RankingBoard.RewardProcess.Add(builder.Build());
				return this;
			}
		}
	}
	
	public class DailyRankingBoard : RankingBoard
	{
	}
	
	public class MultipleDaysRankingBoard : RankingBoard
	{
		public DayOfWeek SeasonEndDay { get; set; }
	}
	
	public class WeeklyRankingBoard : MultipleDaysRankingBoard
	{
	}
	
	public class MonthlyRankingBoard : MultipleDaysRankingBoard
	{
	}

	/*******************************************************************************************************/

	// public abstract class RankingBoard : IRankingBoard
	// {
	// 	public string Name { get; private set; }
	// 	public List<IRewardProcess> RewardProcess { get; private set; }
	// 	public string[] ExcludeRewardChannels { get; private set; }
	//
	// 	public async Task Update()
	// 	{
	// 		foreach (var rewardProcess in RewardProcess)
	// 		{
	// 			await rewardProcess.DoRewardAsync();
	// 		}
	//
	// 		foreach (var rewardProcess in RewardProcess)
	// 		{
	// 			await rewardProcess.StartNewSeason();
	// 		}
	// 	}
	//
	// 	public void SetScore(string key, string user, double score)
	// 	{
	// 	}
	//
	// 	public void GetScore(string key, string user, double score)
	// 	{
	// 	}
	//
	// 	public class Builder<T, TBoard> where T : Builder<T, TBoard>, new() where TBoard : RankingBoard, new()
	// 	{
	// 		protected TBoard RankingBoard = new TBoard();
	//
	// 		public RankingBoard Build()
	// 		{
	// 			return RankingBoard;
	// 		}
	//
	// 		public T SetName(string name)
	// 		{
	// 			RankingBoard.Name = name;
	// 			return (T) this;
	// 		}
	//
	// 		public T SetExcludeRewardChannels(string[] excludeRewardChannels)
	// 		{
	// 			RankingBoard.ExcludeRewardChannels = excludeRewardChannels;
	// 			return (T) this;
	// 		}
	//
	// 		public T AddFixRewardProcess(Action<FixRewardProcess.Builder> builderMethod)
	// 		{
	// 			if (RankingBoard.RewardProcess == null)
	// 				RankingBoard.RewardProcess = new List<IRewardProcess>();
	//
	// 			var builder = new FixRewardProcess.Builder();
	// 			builderMethod(builder);
	//
	// 			RankingBoard.RewardProcess.Add(builder.Build());
	// 			return (T) this;
	// 		}
	//
	// 		public T AddPercentageRewardProcess(Action<PercentageRewardProcess.Builder> builderMethod)
	// 		{
	// 			if (RankingBoard.RewardProcess == null)
	// 				RankingBoard.RewardProcess = new List<IRewardProcess>();
	//
	// 			var builder = new PercentageRewardProcess.Builder();
	// 			builderMethod(builder);
	//
	// 			RankingBoard.RewardProcess.Add(builder.Build());
	// 			return (T) this;
	// 		}
	// 	}
	// }
	//
	// public class DailyRankingBoard : RankingBoard
	// {
	// 	public class Builder : Builder<Builder, DailyRankingBoard>
	// 	{
	// 	}
	// }
	//
	// public class WeeklyRankingBoard : RankingBoard
	// {
	// 	public DayOfWeek SeasonEndDay { get; private set; }
	//
	// 	public class Builder : Builder<Builder, WeeklyRankingBoard>
	// 	{
	// 		public Builder SetSeasonEndDay(DayOfWeek dayOfWeek)
	// 		{
	// 			RankingBoard.SeasonEndDay = dayOfWeek;
	// 			return this;
	// 		}
	// 	}
	// }
	//
	// public class MonthlyRankingBoard : RankingBoard
	// {
	// 	public DayOfWeek SeasonEndDay { get; private set; }
	//
	// 	public class Builder : Builder<Builder, MonthlyRankingBoard>
	// 	{
	// 		public Builder SetSeasonEndDay(DayOfWeek dayOfWeek)
	// 		{
	// 			RankingBoard.SeasonEndDay = dayOfWeek;
	// 			return this;
	// 		}
	// 	}
	// }
}