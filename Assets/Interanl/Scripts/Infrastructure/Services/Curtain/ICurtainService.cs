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

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain
{
    public interface ICurtainService
    {
        public void Init();
        public void ShowCurtain(bool isAnimated = true, Action callback = null);
        public void HideCurtain(bool isAnimated = true, Action callback = null);
        public void HideCurtain(float startDelay, Action callback = null);
    }
}