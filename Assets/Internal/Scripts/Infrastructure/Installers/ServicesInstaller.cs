using UnityEngine;
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