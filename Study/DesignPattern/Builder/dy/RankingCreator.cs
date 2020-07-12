using System;
using System.Collections.Generic;

namespace DesignPattern.Builder.dy
{
	public static class RankingCreator
	{
		public static IList<IRankingBoard> Create(RankingInfo[] infos)
		{
			var boards = new List<IRankingBoard>();
			foreach (var rankingInfo in infos)
			{
				var builder = new RankingBoard.Builder(rankingInfo.BoardType);
				foreach (var process in rankingInfo.RewardProcesses)
				{
					switch (process.RewardProcessType)
					{
						case RewardProcessType.Fix:
							builder.AddFixRewardProcess(processBuilder =>
							{
								UseDelivery(processBuilder, process).SetMaxRank(process.MaxRank)
									.SetMinRank(process.MaxRank);
							});
							break;
						case RewardProcessType.Percent:
							builder.AddPercentageRewardProcess(processBuilder =>
							{
								UseDelivery(processBuilder, process).SetExcludeMinRank(process.MinRank);
							});
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
	
				var board = builder.SetName(rankingInfo.Name)
					.SetExcludeRewardChannels(rankingInfo.ExcludeRewardChannelNames)
					.SetSeasonEndDay(rankingInfo.SeasonEndDay).Build();
	
				boards.Add(board);
			}
	
			return boards;
		}
	
		private static T UseDelivery<T, T2>(RewardProcess.Builder<T, T2> builder, RankingInfo.RewardProcess process)
			where T : RewardProcess.Builder<T, T2>, new() where T2 : RewardProcess, new()
		{
			switch (process.RewardDeliveryType)
			{
				case RewardDeliveryType.Mail:
					return builder.UseMailDelivery();
					break;
				case RewardDeliveryType.Direct:
					return builder.UseDirectDelivery();
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
	
	public class RankingMain
	{
		public static void Do(string[] args)
		{
			var caveBuilder = new RankingBoard.Builder(BoardType.Weekly);
			var ranking = caveBuilder.SetName("cave").AddFixRewardProcess(builder =>
			{
				builder.UseMailDelivery();
				builder.SetMaxRank(100);
			}).AddPercentageRewardProcess(builder =>
			{
				builder.UseDirectDelivery();
				builder.SetExcludeMinRank(100);
			}).Build();
	
			var rankings = RankingCreator.Create(new RankingInfo[11]);
		}
	}
	
	/*******************************************************************************************************/

	// public static class RankingCreator
	// {
	// 	public static IList<IRankingBoard> Create(RankingInfo[] infos)
	// 	{
	// 		var boards = new List<IRankingBoard>();
	// 		foreach (var rankingInfo in infos)
	// 		{
	// 			IRankingBoard board;
	// 			switch (rankingInfo.BoardType)
	// 			{
	// 				case BoardType.Daily:
	// 					var daily = new DailyRankingBoard.Builder();
	// 					board = SetDefault(daily, rankingInfo).Build();
	// 					break;
	// 				case BoardType.Weekly:
	// 					var weekly = new WeeklyRankingBoard.Builder();
	// 					board = SetDefault(weekly, rankingInfo).SetSeasonEndDay(rankingInfo.SeasonEndDay).Build();
	// 					break;
	// 				case BoardType.Monthly:
	// 					var monthly = new MonthlyRankingBoard.Builder();
	// 					board = SetDefault(monthly, rankingInfo).SetSeasonEndDay(rankingInfo.SeasonEndDay).Build();
	// 					break;
	// 				default:
	// 					throw new ArgumentOutOfRangeException();
	// 			}
	// 	
	// 			boards.Add(board);
	// 		}
	// 	
	// 		return boards;
	// 	}
	// 	
	// 	private static T SetDefault<T, T2>(RankingBoard.Builder<T, T2> builder, RankingInfo info)
	// 		where T : RankingBoard.Builder<T, T2>, new() where T2 : RankingBoard, new()
	// 	{
	// 		builder = builder.SetName(info.Name).SetExcludeRewardChannels(info.ExcludeRewardChannelNames);
	// 		foreach (var process in info.RewardProcesses)
	// 		{
	// 			switch (process.RewardProcessType)
	// 			{
	// 				case RewardProcessType.Fix:
	// 					builder.AddFixRewardProcess(processBuilder =>
	// 					{
	// 						UseDelivery(processBuilder, process).SetMaxRank(process.MaxRank)
	// 							.SetMinRank(process.MaxRank);
	// 					});
	// 					break;
	// 				case RewardProcessType.Percent:
	// 					builder.AddPercentageRewardProcess(processBuilder =>
	// 					{
	// 						UseDelivery(processBuilder, process).SetExcludeMinRank(process.MinRank);
	// 					});
	// 					break;
	// 				default:
	// 					throw new ArgumentOutOfRangeException();
	// 			}
	// 		}
	// 	
	// 		return (T) builder;
	// 	}
	//
	// 	private static T UseDelivery<T, T2>(RewardProcess.Builder<T, T2> builder, RankingInfo.RewardProcess process)
	// 		where T : RewardProcess.Builder<T, T2>, new() where T2 : RewardProcess, new()
	// 	{
	// 		switch (process.RewardDeliveryType)
	// 		{
	// 			case RewardDeliveryType.Mail:
	// 				return builder.UseMailDelivery();
	// 				break;
	// 			case RewardDeliveryType.Direct:
	// 				return builder.UseDirectDelivery();
	// 			default:
	// 				throw new ArgumentOutOfRangeException();
	// 		}
	// 	}
	// }
	//
	// public class RankingMain
	// {
	// 	public static void Do(string[] args)
	// 	{
	// 		var caveBuilder = new DailyRankingBoard.Builder();
	// 		var ranking = caveBuilder.SetName("cave").AddFixRewardProcess(builder =>
	// 		{
	// 			builder.UseMailDelivery();
	// 			builder.SetMaxRank(100);
	// 		}).AddPercentageRewardProcess(builder =>
	// 		{
	// 			builder.UseDirectDelivery();
	// 			builder.SetExcludeMinRank(100);
	// 		}).Build();
	//
	// 		var rankings = RankingCreator.Create(new RankingInfo[11]);
	// 	}
	// }
}