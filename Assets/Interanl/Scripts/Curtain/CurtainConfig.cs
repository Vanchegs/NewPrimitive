using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vanchegs
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
