namespace ScoreLogic
{
    public class LevelModel
    {
        public int LevelNumber { get; private set; }

        public void IncrementPrimLevel()
        {
            LevelNumber++;
        }

        public void SetPrimLevel()
        {
            LevelNumber = 1;
        }
    }
}
