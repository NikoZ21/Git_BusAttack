using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxTime(float maxLevelTime)
    {
        slider.maxValue = maxLevelTime;
        slider.value = maxLevelTime;
    }

    public void SetCurrentTime(float currentLevelTime)
    {
        slider.value = currentLevelTime;
    }
}
