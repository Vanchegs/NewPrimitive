// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using YG;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.LeaderboardLogic
{
    public sealed class Leaderboard : ILeaderboard
    {
        private const string LeaderboardName = "";

        public void UpdateLeaderboard(int newScore)
        {
            if (!YandexGame.SDKEnabled)
                return;

            YandexGame.NewLeaderboardScores(LeaderboardName, newScore);
        }
    }
}