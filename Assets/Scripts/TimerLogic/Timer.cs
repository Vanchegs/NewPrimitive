using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private int timerValue = 40;

    private void Start()
    {
        StartCoroutine(TimerDecreaser());
    }

    private IEnumerator TimerDecreaser()
    {
        timerText.text = "" + timerValue;
        timerValue--;
        
        yield return new WaitForSeconds(1);
    }
}
