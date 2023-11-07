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

using System.Collections;
using TMPro;
using UnityEngine;
using Vanchegs.Interanl.Scripts.EventSystem;

namespace Vanchegs.Interanl.Scripts.TimerLogic
{
    public class Timer : MonoBehaviour
    {
        private const int MaxTimerValue = 40;

        [SerializeField] private TMP_Text timerText;

        private int timerValue = 42;

        private void Start() => StartCoroutine(TimerDecreaser());

        public IEnumerator RestartTimer()
        {
            yield return new WaitForSeconds(1);

            timerValue = MaxTimerValue;
            timerText.text = "" + timerValue;
        }

        private IEnumerator TimerDecreaser()
        {
            while (true)
            {
                if (timerValue > 0)
                {
                    timerValue--;
                    timerText.text = "" + timerValue;
                }
                else if (timerValue == 0)
                {
                    StartCoroutine(RestartTimer());
                    EventPack.OnResetOnFirstLevel?.Invoke();
                }

                yield return new WaitForSeconds(1);
            }
        }
    }
}