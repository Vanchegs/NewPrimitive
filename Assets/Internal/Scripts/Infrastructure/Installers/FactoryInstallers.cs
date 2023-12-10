using UnityEngine;
using Vanchegs.Interanl.Scripts.Infrastructure.Factories;
using Zenject;

namespace Vanchegs.Internal.Scripts.Infrastructure.Installers
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