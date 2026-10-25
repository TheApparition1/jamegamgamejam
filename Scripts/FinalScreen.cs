using System;
using TMPro;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    public TextMeshProUGUI totalTime;
    public TextMeshProUGUI bestTime;
    public TimeSave save;

    private void Awake()
    {
        save.totalTime = save.levelTimes[0] +  save.levelTimes[1] + save.levelTimes[2];
        totalTime.text = "Total Time: " + save.totalTime;
        bestTime.text = "Best Time: " + save.bestTime;
    }

    void Start()
    {
        if (save.totalTime > save.bestTime)
        {
            save.bestTime = save.totalTime;
        }
    }
}
