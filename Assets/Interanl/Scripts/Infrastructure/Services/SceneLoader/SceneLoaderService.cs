// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vanchegs.Interanl.Scripts.Infrastructure.Services.CoroutineRunner;
using Zenject;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader
{
    public sealed class SceneLoaderService : ISceneLoaderService
    {
        private readonly ICoroutineRunner coroutineRunner;

        [Inject]
        public SceneLoaderService(ICoroutineRunner coroutineRunner) => 
            this.coroutineRunner = coroutineRunner;

        public void LoadScene(string sceneName, Action onSceneLoadedCallback = null) => 
            coroutineRunner.StartCoroutine(LoadSceneCoroutine(sceneName, onSceneLoadedCallback));

        public string GetCurrentSceneName() => 
            SceneManager.GetActiveScene().name;

        private IEnumerator LoadSceneCoroutine(string sceneName, Action onSceneLoadedCallback)
        {
            if (GetCurrentSceneName() == sceneName)
            {
                onSceneLoadedCallback?.Invoke();
                yield break;
            }

            var loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!loadSceneOperation.isDone)
                yield return new WaitForEndOfFrame();

            onSceneLoadedCallback?.Invoke();
        }
    }
}