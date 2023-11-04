// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using System;
using Vanchegs.Interanl.Scripts.Storages;
using YG;

namespace Vanchegs.Interanl.Scripts.ProgressLogic
{
    public sealed class PersistenProgress : IPersistenProgress
    {
        public Storage Storage { get; private set; }

        public void Save()
        {
            if (!YandexGame.SDKEnabled)
                return;

            Storage ??= Load();

            YandexGame.savesData.storage = Storage;

            YandexGame.SaveProgress();
        }

        public Storage Load(Action callback = null)
        {
            if (YandexGame.savesData.storage == null)
                Storage = YandexGame.savesData.storage = new Storage();
            else
                Storage = YandexGame.savesData.storage;

            callback?.Invoke();

            return Storage;
        }
    }
}