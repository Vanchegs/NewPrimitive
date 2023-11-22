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

using YG;
using System;
using Vanchegs.Interanl.Scripts.Storages;

namespace Vanchegs.Interanl.Scripts.ProgressLogic
{
    public sealed class PersistenProgress : IPersistenProgress
    {
        public Storage Storage { get; private set; } = YandexGame.savesData.storage = new Storage();

        public void Save()
        {
            if (!YandexGame.SDKEnabled)
                return;
        }

        public Storage Load(Action callback = null)
        {
            return Storage;
        }
    }
}