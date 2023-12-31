﻿using YG;
using Zenject;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;
using Vanchegs.Interanl.Scripts.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Constants;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Adv;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Curtain;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.Localization;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader;
using Vanchegs.Interanl.Scripts.ProgressLogic;


namespace Vanchegs.Internal.Scripts.Boot
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

        private void Awake()
        {
            Debug.Log("Awake()");
        }

        private void Start()
        {
            Debug.Log(" Start()");
            if (YandexGame.SDKEnabled)
                Load();

            YandexGame.GetDataEvent += Load;
            YandexGame.SwitchLangEvent += SwitchLangEvent;
        }


        private void Load()
        {
            Debug.Log(" Load()");
            curtainService.Init();
            Debug.Log("curtainService.Init()");
            advService.ShowFullScreenADV();

            Debug.Log("Load::ShowCurtain");

            curtainService.ShowCurtain(true, HideCurtain);
        }

        private void HideCurtain()
        {
            Debug.Log("Start GRA");
            
            Debug.Log("HideCurtain::Start");
            curtainService.HideCurtain(curtainConfig.HideDelay);

            persistenProgress.Load();

            Debug.Log("HideCurtain::Load");
            sceneLoader.LoadScene(SceneName.MainScene, OnSceneLoadedCallback);
        }

        private void OnSceneLoadedCallback()
        {
            Debug.Log("OnSceneLoadedCallback::MainMenuScene");

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
            
            YandexGame.GameReadyAPI();
        }

        private void SwitchLangEvent(string language)
        {
            Debug.Log($"SwitchLangEvent({language})");
            currentLanguage = language;
        }
    }
}