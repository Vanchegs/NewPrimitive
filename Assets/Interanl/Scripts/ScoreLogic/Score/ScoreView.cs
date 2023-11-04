using TMPro;
using UnityEngine;

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text primScoreText;

        private ScoreModel scoreModel;
    
        public void SetViewModel(ScoreModel scoreModel)
        {
            this.scoreModel = scoreModel;
        }

        public void PrimScoreView()
        {
            primScoreText.text = scoreModel.PrimScore + "/" + scoreModel.NeedPrimScore;
        }
    }
}
