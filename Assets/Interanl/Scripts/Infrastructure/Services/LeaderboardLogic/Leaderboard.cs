// **************************************************************** //
//
//   Copyright (c) Vanchegs and RimuruDev. All rights reserved.
//   Project: Primitime 2023
//   Contact: 
//         Vanchegs
//           - GitHub:   https://github.com/Vanchegs
//           - Gmail:    manshin9300@gmail.com
//         RimuruDev
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//
// **************************************************************** //

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