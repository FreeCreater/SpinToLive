using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    [SerializeField] private int startTimeScale = 1;
    [SerializeField] private int maxTimeScale = 3;
    [SerializeField] private int delay = 4;
    [SerializeField] private float step = 0.01f;
    void Start()
    {
        Time.timeScale = startTimeScale;
        InvokeRepeating(nameof(AddScale), 0, delay);
    }

    void AddScale()
    {
        if(Time.timeScale>=maxTimeScale)
            CancelInvoke(nameof(AddScale));
        Time.timeScale += step;
    }
}
