﻿using UnityEngine;
using Vanchegs.Interanl.Scripts.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Constants;
using Vanchegs.Internal.Scripts.Infrastructure.Constants;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Factories
{
    public sealed class UIFactory : IUIFactory
    {
        public CurtainView CreateCurtain()
        {
            var config = Resources.Load<CurtainConfig>(AssetPath.CurtainConfig);

            var view = Object.Instantiate(config.CurtainView);
            view.Constructor(config.AnimationDuration);

            return view;
        }
    }
}