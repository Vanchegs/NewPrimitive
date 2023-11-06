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

using UnityEngine;
using NaughtyAttributes;

namespace Vanchegs.Interanl.Scripts.Curtain
{
    [CreateAssetMenu(menuName = "StaticData/Create CurtainConfig", fileName = "CurtainConfig", order = 0)]
    public sealed class CurtainConfig : ScriptableObject
    {
        [field: SerializeField] public CurtainView CurtainView { get; private set; }

        [field: Space(20)]
        [field: SerializeField]
        public float HideDelay { get; private set; } = 1.3f;

        [field: SerializeField] public float AnimationDuration { get; private set; } = 1.5f;
    }
}