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
using System.Collections;

namespace Vanchegs.Interanl.Scripts.ProgressLogic
{
    [DisallowMultipleComponent]
    public sealed class AutoSaver : MonoBehaviour
    {
        [SerializeField] private float autoSaveCooldown = 3f;

        private IPersistenProgress progress;

        [Inject]
        private void Constructor(IPersistenProgress progress) =>
            this.progress = progress;

        private void Start() =>
            StartCoroutine(AutoSave());

        private IEnumerator AutoSave()
        {
            yield return new WaitForSeconds(autoSaveCooldown);

            progress?.Save();
        }
    }
}