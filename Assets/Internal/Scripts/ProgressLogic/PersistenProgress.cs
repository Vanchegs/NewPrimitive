using YG;
using System;
using Vanchegs.Interanl.Scripts.ScoreLogic.Level;
using Zenject;

namespace Vanchegs.Interanl.Scripts.ProgressLogic
{
    public sealed class PersistenProgress : IPersistenProgress
    {
        public int BestLevel { get; set; }

        private LevelController levelController;
        
        [Inject]
        private void Constructor(LevelController levelController)
        {
            this.levelController = levelController;
        }

        public void Save()
        {
            if (!YandexGame.SDKEnabled)
                return;

            BestLevel = levelController.LevelModel.BestLevelNumber;
            YandexGame.SaveProgress();
        }

        public int Load(Action callback = null)
        {
            return BestLevel;
        }
    }
}