<<<<<<< HEAD:Assets/Interanl/Scripts/ProgressLogic/AutoSaver.cs
﻿// **************************************************************** //
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

using Zenject;
=======
﻿using Zenject;
>>>>>>> main:Assets/Interanal/Scripts/ProgressLogic/AutoSaver.cs
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
<<<<<<< HEAD:Assets/Interanl/Scripts/ProgressLogic/AutoSaver.cs

            // progress?.Save();
=======
            
            progress?.Save();
>>>>>>> main:Assets/Interanal/Scripts/ProgressLogic/AutoSaver.cs
        }
    }
}