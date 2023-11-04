// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - Gists:    https://gist.github.com/RimuruDev/af759ce6d9768a38f6838d8b7cc94fc8
// **************************************************************** //

using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Internal.Codebase.Utilities.Editor.SceneSwitcher
{
    public sealed class SceneSwitcher : EditorWindow
    {
        private bool showAllScenes;

        private void OnGUI()
        {
            GUILayout.Label("Scene Switcher", EditorStyles.boldLabel);

            EditorGUI.BeginChangeCheck();

            showAllScenes = EditorGUILayout.Toggle(
                "Show Absolutely All Scenes",
                showAllScenes);

            if (EditorGUI.EndChangeCheck())
                Repaint();

            var scenePaths =
                showAllScenes
                    ? GetAllScenePaths()
                    : GetScenePathsByBuildSettings();

            foreach (var scenePath in scenePaths)
                if (GUILayout.Button(Path.GetFileNameWithoutExtension(scenePath)))
                    EditorSceneManager.OpenScene(scenePath);
        }

        [MenuItem("RimuruDevTools/Scene Switcher")]
        private static void ShowWindow()
        {
            GetWindow(typeof(SceneSwitcher));
        }

        private string[] GetScenePathsByBuildSettings()
        {
            var paths = new string[EditorBuildSettings.scenes.Length];

            for (var i = 0; i < EditorBuildSettings.scenes.Length; i++)
                paths[i] = EditorBuildSettings.scenes[i].path;

            return paths;
        }

        private string[] GetAllScenePaths()
        {
            string[] scenePaths;
            var guids = AssetDatabase.FindAssets("t:Scene");

            scenePaths = new string[guids.Length];

            for (var i = 0; i < scenePaths.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                scenePaths[i] = path;
            }

            return scenePaths;
        }
    }
}