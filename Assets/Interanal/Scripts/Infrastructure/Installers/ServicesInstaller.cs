<<<<<<< HEAD:Assets/Interanl/Scripts/Infrastructure/Installers/ServicesInstaller.cs
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
>>>>>>> main:Assets/Interanal/Scripts/Infrastructure/Installers/ServicesInstaller.cs
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Adv;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.CoroutineRunner;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.LeaderboardLogic;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader;
using Vanchegs.Interanl.Scripts.ProgressLogic;
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
            Container.Bind<IPersistenProgress>().To<PersistenProgress>().AsSingle();
            Container.Bind<ILeaderboard>().To<Leaderboard>().AsSingle();
            Container.Bind<IADVService>().To<ADVService>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
        }
    }
}