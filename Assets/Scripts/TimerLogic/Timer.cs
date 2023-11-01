using System;
using System.Collections;
using ScoreLogic;
using TMPro;
using UnityEngine;
using Vanchegs;

public class Timer : MonoBehaviour
{
    private const int MaxTimerValue = 42;
    
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private ScoreController scoreController;
    
    private int timerValue = 40;

    private void Start()
    {
        StartCoroutine(TimerDecreaser());
    }

    private void RestartTimer()
    {
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
                EventPack.OnReloadTimerCoroutine?.Invoke();
                EventPack.OnReturnToFirstLevel?.Invoke();
                scoreController.ResetPrimLevel();
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void OnEnable() => EventPack.OnReloadTimerCoroutine += RestartTimer;

    private void OnDisable() => EventPack.OnReloadTimerCoroutine -= RestartTimer;
}
