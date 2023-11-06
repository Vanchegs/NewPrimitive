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