using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Vanchegs;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private int timerValue = 40;

    private void Start()
    {
        StartCoroutine(TimerDecreaser());
    }

    private void RestartTimer()
    {
        timerValue = 40;
        timerText.text = "" + timerValue;
    }

    private IEnumerator TimerDecreaser()
    {
        while (true)
        {
            if (timerValue >= 0)
            {
                timerValue--;
                timerText.text = "" + timerValue;
            }
            else
            {
                EventPack.OnReloadTimerCoroutine?.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void OnEnable() => EventPack.OnReloadTimerCoroutine += RestartTimer;

    private void OnDisable() => EventPack.OnReloadTimerCoroutine -= RestartTimer;
}
