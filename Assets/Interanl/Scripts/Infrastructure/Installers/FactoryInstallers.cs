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

using Zenject;
using UnityEngine;
using Vanchegs.Interanl.Scripts.Infrastructure.Factories;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class FactoryInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }
    }
}