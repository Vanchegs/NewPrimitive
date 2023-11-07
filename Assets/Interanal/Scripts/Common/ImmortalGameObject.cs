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
using UnityEngine;

namespace Vanchegs.Interanl.Scripts.Common
{
    [DisallowMultipleComponent]
    public sealed class ImmortalGameObject : MonoBehaviour
    {
        [SerializeField] private bool setParentNull = true;
        [SerializeField] private IncludeImmortalGameObject includeImmortalGameObject = IncludeImmortalGameObject.Awake;

        private void Awake()
        {
            if (includeImmortalGameObject != IncludeImmortalGameObject.Awake)
                return;

            ApplyDontDestroyOnLoad();
        }

        private void Start()
        {
            if (includeImmortalGameObject != IncludeImmortalGameObject.Start)
                return;

            ApplyDontDestroyOnLoad();
        }

        private void ApplyDontDestroyOnLoad()
        {
            if (setParentNull)
                transform.SetParent(null);

            DontDestroyOnLoad(gameObject);
        }

        [Serializable]
        public enum IncludeImmortalGameObject : byte
        {
            Awake = 0,
            Start = 1,
        }
    }
}