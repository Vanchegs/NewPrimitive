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

using YG;
using System;
using Vanchegs.Interanl.Scripts.Storages;

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