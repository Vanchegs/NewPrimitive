using System;

namespace Vanchegs.Interanl.Scripts.Storages
{
    [Serializable]
    public sealed class Storage
    {
        public int bestScore;

        public Storage() =>
            bestScore = 0;

        public Storage(int defaultScore) =>
            bestScore = defaultScore;
    }
}