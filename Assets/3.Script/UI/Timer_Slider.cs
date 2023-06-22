using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Slider : MonoBehaviour
{
    public Slider sliderTime;
    public float LimitTime = 150f;


    private void Start()
    {
        sliderTime = GetComponent<Slider>();
        
        sliderTime.maxValue = LimitTime;
        sliderTime.value = LimitTime;
    }
    void Update()
    {
        LimitTime -= Time.deltaTime;
        if (sliderTime.value > 0.0f)
        {
            sliderTime.value -= Time.deltaTime;
        }
    }
}
