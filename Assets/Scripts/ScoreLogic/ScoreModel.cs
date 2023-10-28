namespace ScoreLogic
{
    public class ScoreModel
    {
        public int PrimScore { get; private set; }
        public int NeedPrimScore { get; private set; }

        public void IncrementPrimScore()
        {
            PrimScore++;
        }

        public void UpNeedScore()
        {
            NeedPrimScore += 10;
        }

        public void ResetPrimScore()
        {
            PrimScore = 0;
            NeedPrimScore = 10;
        }
    }
}
