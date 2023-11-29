using Zenject;
using UnityEngine;
using Vanchegs.Interanl.Scripts.ProgressLogic;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.LeaderboardLogic;
using Vanchegs.Internal.Scripts.ScoreLogic.Level;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Level
{
    public sealed class LevelController : MonoBehaviour, ILevelController
    {
        [SerializeField] private LevelView levelView;
        public LevelModel LevelModel { get; set; }
        private ILeaderboard leaderboard;
        private IPersistenProgress persistenProgress;

        [Inject]
        private void Constructor(IPersistenProgress persistenProgress, ILeaderboard leaderboard)
        {
            this.persistenProgress = persistenProgress;
            this.leaderboard = leaderboard;
        }

        private void Start()
        {
            LevelModel = new LevelModel(persistenProgress, leaderboard);

            levelView.SetLevelModel(LevelModel);
            LevelModel.SetPrimLevel();
            LevelModel.CheckPrimBestLevel();
            levelView.PrimLevelView();
        }

        public void UpPrimLevelNumber()
        {
            LevelModel.IncrementPrimLevel();
            LevelModel.CheckPrimBestLevel();
            levelView.PrimLevelView();

            persistenProgress?.Save();
        }

        public void ResetPrimLevelNumber()
        {
            LevelModel.ResetLevelNumber();
            LevelModel.CheckPrimBestLevel();
            levelView.PrimLevelView();

            persistenProgress?.Save();
        }
    }
}