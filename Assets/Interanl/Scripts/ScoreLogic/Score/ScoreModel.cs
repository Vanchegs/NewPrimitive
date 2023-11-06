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

namespace Vanchegs.Interanl.Scripts.ScoreLogic.Score
{
    public class ScoreModel
    {
        public int PrimScore { get; private set; }
        public int NeedPrimScore { get; private set; }

        public void IncrementPrimScore() => PrimScore++;

        public void UpNeedScore() => NeedPrimScore += 10;

        public void ResetPrimScore() => PrimScore = 0;

        public void ResetPrimNeedScore() => NeedPrimScore = 10;
    }
}