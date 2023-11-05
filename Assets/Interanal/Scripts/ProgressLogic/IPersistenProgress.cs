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

namespace Vanchegs.Interanl.Scripts.ProgressLogic
{
    public interface IPersistenProgress
    {
        public Storage Storage { get; }
        public void Save();
        public Storage Load(Action callback = null);
    }
}