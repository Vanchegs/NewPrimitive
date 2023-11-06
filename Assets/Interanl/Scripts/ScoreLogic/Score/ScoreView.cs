// **************************************************************** //
//
//   Copyright (c) Vanchegs and RimuruDev. All rights reserved.
//   Project: Primitime 2023
//   Contact: 
//         Vanchegs
//           - GitHub:   https://github.com/Vanchegs
//           - Gmail:    manshin9300@gmail.com
//         RimuruDev
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//
// **************************************************************** //

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
