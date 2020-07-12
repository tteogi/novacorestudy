using System;
using System.Threading.Tasks;

namespace DesignPattern.Builder.dy
{
	public interface IRankingBoard
	{
	}
	
	public interface IMultipleDaysRankingBoard
	{
		DayOfWeek SeasonEndDay { get; set; }
	}

	public interface IRewardDelivery
	{
	}

	public interface IRewardProcess
	{
		public Task StartNewSeason();
		public Task DoRewardAsync();
	}

}