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

        private IEnumerator TimerDecreaser()
        {
            while (true)
            {
                timerCount--;
                if (timerCount == 0)
                {
                    EventPack.OnReturnToFirstLevel?.Invoke();
                }
                
                if (scoreController.cleanFlag)
                {
                    EventPack.OnReloadTimerCoroutine?.Invoke();
                    timerCount = 41;
                }
                yield return new WaitForSecondsRealtime(timerCoolDown);
            }
        }
    }
}
