using System;

namespace Vanchegs.Interanl.Scripts.ProgressLogic
{
    public interface IPersistenProgress
    {
        public int BestLevel { get; set; }
        public void Save();
        public int Load(Action callback = null);
    }
}