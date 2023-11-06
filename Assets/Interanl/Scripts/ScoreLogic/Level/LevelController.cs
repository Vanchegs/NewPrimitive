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

using Zenject;
using UnityEngine;
using Vanchegs.Interanl.Scripts.ProgressLogic;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.LeaderboardLogic;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Level
{
    public sealed class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelView levelView;
        private LevelModel levelModel;
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
            levelModel = new LevelModel(persistenProgress, leaderboard);

            levelView.SetLevelModel(levelModel);
            levelModel.SetPrimLevel();
            levelModel.CheckPrimBestLevel();
            levelView.PrimLevelView();
        }

        public void UpPrimLevelNumber()
        {
            levelModel.IncrementPrimLevel();
            levelModel.CheckPrimBestLevel();
            levelView.PrimLevelView();

            persistenProgress?.Save();
        }

        public void ResetPrimLevelNumber()
        {
            levelModel.ResetLevelNumber();
            levelModel.CheckPrimBestLevel();
            levelView.PrimLevelView();

            persistenProgress?.Save();
        }
    }
}