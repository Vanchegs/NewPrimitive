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
using Vanchegs.Interanl.Scripts.Infrastructure.Factories;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.CoroutineRunner;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader;
using Zenject;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class ServicesInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.Bind<ICurtainService>().To<CurtainService>().AsSingle();
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
        }
    }
}