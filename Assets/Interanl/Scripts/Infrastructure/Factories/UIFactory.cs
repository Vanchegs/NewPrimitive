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

using UnityEngine;
using Vanchegs.Interanl.Scripts.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Constants;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Factories
{
    public sealed class UIFactory : IUIFactory
    {
        public CurtainView CreateCurtain()
        {
            var config = Resources.Load<CurtainConfig>(AssetPath.Curtain);

            var view = Object.Instantiate(config.CurtainView);
            view.Constructor(config.AnimationDuration);

            return view;
        }
    }
}