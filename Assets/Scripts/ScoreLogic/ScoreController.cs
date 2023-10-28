using UnityEngine;
using Vanchegs;
using Vanchegs.PrimitiveLogic;

namespace ScoreLogic
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private LevelController levelController;
        [SerializeField] private PrimitiveFactory primitiveFactory;
        
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
            if (scoreModel.PrimScore >= scoreModel.NeedPrimScore - 1) 
                UpPrimLevel();
            
            scoreModel.IncrementPrimScore();
            scoreView.PrimScoreView();
            EventPack.OnClickScreen?.Invoke();
            EventPack.OnSwitchToNextLevel?.Invoke();
        }

        private void UpPrimLevel()
        {
            scoreModel.UpNeedScore();
            scoreModel.ResetPrimScore();
            levelController.UpPrimLevelNumber();
            primitiveFactory.OffPrimitives();
        }
    }
}
