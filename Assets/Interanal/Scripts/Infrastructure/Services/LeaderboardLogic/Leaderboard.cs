using YG;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.LeaderboardLogic
{
    public sealed class Leaderboard : ILeaderboard
    {
        private const string LeaderboardName = "PrimitiveLeaderboard";

        public void UpdateLeaderboard(int newScore)
        {
            if (!YandexGame.SDKEnabled)
                return;

            YandexGame.NewLeaderboardScores(LeaderboardName, newScore);
        }
    }
}