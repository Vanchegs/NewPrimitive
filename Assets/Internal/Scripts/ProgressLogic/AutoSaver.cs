﻿using Zenject;
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

        private void OnDisable() =>
            progress?.Save();

        private void OnDestroy() =>
            progress?.Save();

        private void OnApplicationQuit() =>
            progress?.Save();


        private IEnumerator AutoSave()
        {
            yield return new WaitForSeconds(autoSaveCooldown);
            
            progress?.Save();
        }
    }
}