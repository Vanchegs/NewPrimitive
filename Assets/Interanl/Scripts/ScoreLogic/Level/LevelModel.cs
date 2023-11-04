using Vanchegs.Interanl.Scripts.Infrastructure.Services.LeaderboardLogic;
using Vanchegs.Interanl.Scripts.ProgressLogic;
using Vanchegs.Interanl.Scripts.Storages;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Level
{
    public sealed class LevelModel
    {
        private readonly IPersistenProgress persistenProgress;
        private readonly ILeaderboard leaderboard;
        public int LevelNumber { get; private set; }
        public int BestLevelNumber { get; private set; }

        public LevelModel(IPersistenProgress persistenProgress, ILeaderboard leaderboard)
        {
            this.persistenProgress = persistenProgress;
            this.leaderboard = leaderboard;
            BestLevelNumber = this.persistenProgress.Storage.bestLevel;
        }

        public void IncrementPrimLevel() => LevelNumber++;

        public void SetPrimLevel() => LevelNumber = 1;

        public void ResetLevelNumber() => LevelNumber = 1;

        public void CheckPrimBestLevel()
        {
            if (LevelNumber > BestLevelNumber - 1)
            {
                BestLevelNumber = LevelNumber;
                persistenProgress.Storage.bestLevel = BestLevelNumber;
                leaderboard?.UpdateLeaderboard(persistenProgress.Storage.bestLevel);
            }
        }
    }
}