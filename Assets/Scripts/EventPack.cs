using System;
using UnityEngine;

namespace Vanchegs
{
    public sealed class EventPack : MonoBehaviour
    {
        public static Action OnClickScreen;

        public static Action OnSwitchToNextLevel;

        public static Action OnReturnToFirstLevel;

        public static Action OnReloadTimerCoroutine;
    }
}
