using TMPro;
using UnityEngine;

namespace ScoreLogic
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelNumberText;

        private LevelModel levelModel;

        public void SetLevelModel(LevelModel levelModel)
        {
            this.levelModel = levelModel;
        }

        public void PrimLevelView()
        {
            levelNumberText.text = "" + levelModel.LevelNumber;
        }
    }
}
