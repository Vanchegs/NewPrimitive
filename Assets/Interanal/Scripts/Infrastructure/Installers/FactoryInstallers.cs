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