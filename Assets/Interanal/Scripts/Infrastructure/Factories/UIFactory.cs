<<<<<<< HEAD:Assets/Interanl/Scripts/Infrastructure/Factories/UIFactory.cs
﻿// **************************************************************** //
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

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> main:Assets/Interanal/Scripts/Infrastructure/Factories/UIFactory.cs
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