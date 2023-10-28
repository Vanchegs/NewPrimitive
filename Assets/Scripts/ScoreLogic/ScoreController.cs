using UnityEngine;
using Vanchegs;

namespace ScoreLogic
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private LevelController levelController;

        private ScoreModel scoreModel;

        private void Start()
        {
            scoreModel = new ScoreModel();
            scoreModel.UpNeedScore();
            scoreView.SetViewModel(scoreModel);
            scoreView.PrimScoreView();
        }

        public void Click()
        {
            if (scoreModel.PrimScore >= scoreModel.NeedPrimScore)
            {
                UpPrimLevel();
            }
            scoreModel.IncrementPrimScore();
            scoreView.PrimScoreView();
            EventPack.OnClickScreen?.Invoke();
            EventPack.OnSwitchToNextLevel?.Invoke();
        }

        private void UpPrimLevel()
        {
            scoreModel.UpNeedScore();
            levelController.UpPrimLevelNumber();
        }
    }
}
