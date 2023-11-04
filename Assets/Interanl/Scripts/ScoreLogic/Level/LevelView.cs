using TMPro;
using UnityEngine;
using Vanchegs.Interanl.Scripts.ProgressLogic;
using Zenject;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelNumberText;
        [SerializeField] private TMP_Text bestLevelNumberText;

        [Inject] private IPersistenProgress persistenProgress;
        
        private LevelModel levelModel;

        public void SetLevelModel(LevelModel levelModel)
        {
            this.levelModel = levelModel;
        }

        public void PrimLevelView()
        {
            levelNumberText.text = $"{levelModel.LevelNumber}";
            bestLevelNumberText.text = $"{levelModel.BestLevelNumber}";
        }
    }
}