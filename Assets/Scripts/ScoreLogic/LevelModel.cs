namespace ScoreLogic
{
    public class LevelModel
    {
        public int LevelNumber { get; private set; }

        public void IncrementPrimLevel()
        {
            LevelNumber++;
        }

        private void ResetPrimLevel()
        {
            LevelNumber++;
        }
    }
}
