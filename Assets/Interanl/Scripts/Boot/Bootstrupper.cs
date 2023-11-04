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

using YG;
using Zenject;
using UnityEngine;
using System.Linq;
using NaughtyAttributes;
using Vanchegs.Interanl.Scripts.Curtain;
using Vanchegs.Interanl.Scripts.ProgressLogic;
using Vanchegs.Interanl.Scripts.Infrastructure.Constants;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Adv;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Localization;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader;

namespace Vanchegs.Interanl.Scripts.Boot
{
    [DisallowMultipleComponent]
    public sealed class Bootstrupper : MonoBehaviour
    {
        [SerializeField, ReadOnly] private string currentLanguage = "ru";

        private IADVService advService;
        private ISceneLoaderService sceneLoader;
        private ICurtainService curtainService;
        private IPersistenProgress persistenProgress;
        private CurtainConfig curtainConfig;

        [Inject]
        private void Constructor(
            CurtainConfig curtainConfig,
            IADVService advService,
            ISceneLoaderService sceneLoader,
            ICurtainService curtainService,
            IPersistenProgress persistenProgress)
        {
            this.curtainConfig = curtainConfig;
            this.persistenProgress = persistenProgress;
            this.curtainService = curtainService;
            this.sceneLoader = sceneLoader;
            this.advService = advService;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled)
                Load();

            YandexGame.GetDataEvent += Load;
            YandexGame.SwitchLangEvent += SwitchLangEvent;
        }

        private void OnDestroy()
        {
            YandexGame.SwitchLangEvent -= SwitchLangEvent;
            YandexGame.GetDataEvent -= Load;
        }

        private void Load()
        {
            curtainService.Init();

            advService.ShowFullScreenADV();

            curtainService.ShowCurtain(true, HideCurtain);
        }

        private void HideCurtain()
        {
            curtainService.HideCurtain(curtainConfig.HideDelay);

            persistenProgress.Load();

            sceneLoader.LoadScene(SceneName.MainScene, OnSceneLoadedCallback);
        }

        private void OnSceneLoadedCallback()
        {
            var language = currentLanguage switch
            {
                "ru" => Language.Ru,
                "en" => Language.En,
                _ => Language.Ru
            };

            foreach (var localizationComponents in FindObjectsOfType<SetLanguage>().Where(x => x != null).ToList())
            {
                localizationComponents.UpdateLanguage(language);
            }
        }

        private void SwitchLangEvent(string language)
        {
            Debug.Log($"<color=magenta>SwitchLangEvent({language})</color>");
            currentLanguage = language;
        }
    }
}