using System.Timers;
using UnityEngine.UI;
using UnityEngine;

namespace Vanchegs
{
    public class TimerCircleAnim : MonoBehaviour
    {
        [SerializeField] private Image timerCircleBar;
        private float maxValue = 40f;
        private float value;
        
        private Timer timer;

        private void FixedUpdate() => FillDecrease();

        private void RestartFillDecreaser() => value = -2;

        private void FillDecrease()
        {
            value += Time.deltaTime;
            float fillAmount = 1 - (float)value / maxValue;
            timerCircleBar.fillAmount = fillAmount;
        }

        private void OnEnable() => EventPack.OnReloadTimerCoroutine += RestartFillDecreaser;

        private void OnDisable() => EventPack.OnReloadTimerCoroutine -= RestartFillDecreaser;
    }
}
