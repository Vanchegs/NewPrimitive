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
using NaughtyAttributes;
using UnityEngine;
using Vanchegs.Interanl.Scripts.Curtain;
using Zenject;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class ConfigInstaller : MonoInstaller
    {
        [SerializeField, Expandable] private CurtainConfig CurtainConfig;

        public override void InstallBindings()
        {
            Container.Bind<CurtainConfig>().FromInstance(CurtainConfig).AsSingle();
        }
    }
}