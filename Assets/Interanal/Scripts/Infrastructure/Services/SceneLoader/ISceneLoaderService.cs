using System;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService
    {
        public void LoadScene(string sceneName, Action onSceneLoadedCallback = null);
        public string GetCurrentSceneName();
    }
}