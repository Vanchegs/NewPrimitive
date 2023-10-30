using UnityEngine;
using UnityEngine.UI;

namespace Vanchegs
{
   public class CircleTimer : MonoBehaviour
   {
      private const float maxValue = 40f;
      
      [SerializeField] private Image timerCircleBar;
      
      private float value;

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
