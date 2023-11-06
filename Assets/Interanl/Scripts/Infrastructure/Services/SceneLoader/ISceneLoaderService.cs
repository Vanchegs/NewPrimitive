// **************************************************************** //
//
//   Copyright (c) Vanchegs and RimuruDev. All rights reserved.
//   Project: Primitime 2023
//   Contact: 
//         Vanchegs
//           - GitHub:   https://github.com/Vanchegs
//           - Gmail:    manshin9300@gmail.com
//         RimuruDev
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//
// **************************************************************** //

using System;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService
    {
        public void LoadScene(string sceneName, Action onSceneLoadedCallback = null);
        public string GetCurrentSceneName();
    }
}