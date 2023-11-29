using Vanchegs.Interanl.Scripts.ScoreLogic.Level;

namespace Vanchegs.Internal.Scripts.ScoreLogic.Level
{
    public interface ILevelController
    {
        public LevelModel LevelModel { get; set; }
        void UpPrimLevelNumber();
        void ResetPrimLevelNumber();
    }
}