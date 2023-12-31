﻿using UnityEngine;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Adv;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.CoroutineRunner;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.LeaderboardLogic;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader;
using Vanchegs.Interanl.Scripts.ProgressLogic;
using Vanchegs.Interanl.Scripts.ScoreLogic.Level;
using Vanchegs.Internal.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Internal.Scripts.ScoreLogic.Level;
using Zenject;

namespace Vanchegs.Internal.Scripts.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class ServicesInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.Bind<ICurtainService>().To<CurtainService>().AsSingle();
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
            Container.Bind<IPersistenProgress>().To<PersistenProgress>().AsSingle();
            Container.Bind<ILevelController>().To<LevelController>().AsSingle();
            Container.Bind<ILeaderboard>().To<Leaderboard>().AsSingle();
            Container.Bind<IADVService>().To<ADVService>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
        }
    }
}