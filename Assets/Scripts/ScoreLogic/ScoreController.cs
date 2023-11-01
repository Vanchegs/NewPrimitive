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
        [SerializeField] private CurtainView curtain;
        
        [SerializeField] private GameObject button;
        
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
            if (scoreModel.PrimScore >= scoreModel.NeedPrimScore - 1)
                UpPrimLevel();
            
            scoreModel.IncrementPrimScore();
            scoreView.PrimScoreView();
            EventPack.OnClickScreen?.Invoke();
            EventPack.OnSwitchToNextLevel?.Invoke();
        }

        private void UpPrimLevel()
        {
            button.gameObject.SetActive(false);
            scoreModel.ResetPrimScore();
            curtain.ShowCurtain(true,null);
            levelController.UpPrimLevelNumber();
            primitiveFactory.OffPrimitives();
            curtain.HideCurtain(2,null);
            button.gameObject.SetActive(true);
            scoreModel.UpNeedScore();
            EventPack.OnReloadTimerCoroutine?.Invoke();
        }

        public void ResetPrimLevel()
        {
            scoreModel.ResetPrimScore();
            scoreModel.ResetPrimNeedScore();
            levelController.ResetPrimLevelNumber();
            primitiveFactory.OffPrimitives();
        }

        private void OnEnable() => EventPack.OnReturnToFirstLevel += ResetPrimLevel;

        private void OnDisable() => EventPack.OnReturnToFirstLevel -= ResetPrimLevel;
    }
}
