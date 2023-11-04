using System;
using System.Collections.Generic;
using UnityEngine;
using Vanchegs.Interanl.Scripts.EventSystem;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Interanl.Scripts.ScoreLogic.Level;
using Zenject;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private ScoreView scoreView;
        [Inject] private ICurtainService curtain;
        [SerializeField] private LevelSwitcher levelSwitcher;

        private ScoreModel scoreModel;

        private void Start()
        {
            scoreModel = new ScoreModel();
            scoreModel.UpNeedScore();
            scoreView.SetViewModel(scoreModel);
            scoreView.PrimScoreView();
            Debug.Log($"curtain is null??? => {curtain == null}");

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