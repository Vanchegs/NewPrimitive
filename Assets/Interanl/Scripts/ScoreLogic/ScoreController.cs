using UnityEngine;
using Vanchegs;

namespace ScoreLogic
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private CurtainView curtain;
        [SerializeField] private LevelSwitcher levelSwitcher;
        
        private ScoreModel scoreModel;
        
        private void Start()
        {
            scoreModel = new ScoreModel();
            scoreModel.UpNeedScore();
            scoreView.SetViewModel(scoreModel);
            scoreView.PrimScoreView();
            curtain.HideCurtain(1, null);
        }

        public void Click()
        {
            scoreModel.IncrementPrimScore();
            scoreView.PrimScoreView();
            EventPack.OnClickScreen?.Invoke();
            
            if (scoreModel.PrimScore >= scoreModel.NeedPrimScore)
                EventPack.OnSwitchToNextLevel?.Invoke();
        }

        public void ReturnPrimScore()
        {
            scoreModel.ResetPrimScore();
            scoreModel.ResetPrimNeedScore();
            scoreView.PrimScoreView();
        }

        public void UpLevelPrimScore()
        {
            scoreModel.ResetPrimScore();
            scoreModel.UpNeedScore();
            scoreView.PrimScoreView();
        }
    }
}
