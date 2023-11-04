using UnityEngine;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelView levelView;

        private LevelModel levelModel;

        private void Start()
        {
            levelModel = new LevelModel();
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
        }

        public void ResetPrimLevelNumber()
        {
            levelModel.ResetLevelNumber();
            levelModel.CheckPrimBestLevel();
            levelView.PrimLevelView();
        }
    }
}
