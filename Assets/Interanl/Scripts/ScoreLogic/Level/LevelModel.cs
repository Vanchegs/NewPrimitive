namespace Vanchegs.Interanl.Scripts.ScoreLogic.Level
{
    public class LevelModel
    {
        public int LevelNumber { get; private set; }
        public int BestLevelNumber { get; private set; }

        public void IncrementPrimLevel() => LevelNumber++;

        public void SetPrimLevel() => LevelNumber = 1;

        public void ResetLevelNumber() => LevelNumber = 1;

        public void CheckPrimBestLevel()
        {
            if (LevelNumber > BestLevelNumber - 1)
                BestLevelNumber = LevelNumber;
        }
    }
}
