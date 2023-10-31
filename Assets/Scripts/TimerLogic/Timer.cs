using System.Collections;
using ScoreLogic;
using UnityEngine;

namespace Vanchegs.LevelController
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private ScoreController scoreController;
        
        private int timerCount;
        private int timerCoolDown;
        
        private void Start()
        {
            timerCoolDown = 1;
            timerCount = 41;
            StartCoroutine(TimerDecreaser());
        }

        private void FixedUpdate()
        {
            if (!scoreController.cleanFlag) return;
            timerCount = 41;
            EventPack.OnReloadTimerCoroutine?.Invoke();
        }

        private IEnumerator TimerDecreaser()
        {
            while (true)
            {
                timerCount--;
                if (timerCount == 0)
                {
                    EventPack.OnReturnToFirstLevel?.Invoke();
                }
                yield return new WaitForSecondsRealtime(timerCoolDown);
            }
        }
    }
}
