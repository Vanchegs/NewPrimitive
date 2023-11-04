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