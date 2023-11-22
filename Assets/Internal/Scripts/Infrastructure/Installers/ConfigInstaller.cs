using NaughtyAttributes;
using UnityEngine;
using Vanchegs.Interanl.Scripts.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Localization;
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