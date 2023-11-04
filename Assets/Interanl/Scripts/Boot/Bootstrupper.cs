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
using Vanchegs.Interanl.Scripts.Infrastructure.Constants;
using Vanchegs.Interanl.Scripts.Infrastructure.Factories;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader;
using Vanchegs.Interanl.Scripts.ProgressLogic;
using YG;

namespace Vanchegs.Interanl.Scripts.Boot
{
    [DisallowMultipleComponent]
    public sealed class Bootstrupper : MonoBehaviour
    {
        private IUIFactory uiFactory;
        private ISceneLoaderService sceneLoader;
        private ICurtainService curtainService;
        private IPersistenProgress persistenProgress;

        [Inject]
        private void Constructor(
            IUIFactory uiFactory,
            ISceneLoaderService sceneLoader,
            ICurtainService curtainService,
            IPersistenProgress persistenProgress)
        {
            this.persistenProgress = persistenProgress;
            this.curtainService = curtainService;
            this.sceneLoader = sceneLoader;
            this.uiFactory = uiFactory;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled)
            {
                Load();
            }

            YandexGame.GetDataEvent += Load;
        }

        private void Load()
        {
            curtainService.Init();

            curtainService.ShowCurtain(true, HideCurtain);
        }

        private void HideCurtain()
        {
            curtainService.HideCurtain(1.5f);

            persistenProgress.Load();

            sceneLoader.LoadScene(SceneName.MainScene);
        }
    }
}