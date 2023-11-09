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
using Zenject;
using Vanchegs.Interanl.Scripts.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Factories;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain
{
    public sealed class CurtainService : ICurtainService
    {
        private readonly IUIFactory uiFactory;
        private CurtainView curtainView;

        [Inject]
        public CurtainService(IUIFactory uiFactory) =>
            this.uiFactory = uiFactory;

        public void Init() =>
            curtainView = uiFactory.CreateCurtain();

        public void ShowCurtain(bool isAnimated = true, Action callback = null) =>
            curtainView.ShowCurtain(isAnimated, callback);

        public void HideCurtain(bool isAnimated = true, Action callback = null) =>
            curtainView.HideCurtain(isAnimated, callback);

        public void HideCurtain(float startDelay, Action callback = null) =>
            curtainView.HideCurtain(startDelay, callback);
    }
}