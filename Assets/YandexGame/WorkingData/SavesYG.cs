﻿using Vanchegs.Interanl.Scripts.ProgressLogic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public IPersistenProgress PersistenProgress;
    }
}
