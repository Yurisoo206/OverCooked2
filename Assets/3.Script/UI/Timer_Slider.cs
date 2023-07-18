using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Slider : MonoBehaviour
{
    public Slider sliderTime;
    public Image fill;
    public float LimitTime = 150f;

    Color _Red;
    Color _Orange;
    private void Start()
    {
        _Red = new Color(1,0,0,1);
        _Orange = new Color(1,0.6f,0,1);
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
        if (sliderTime.value <= 80f)
        {
            fill.color = _Orange;
        }
        if (sliderTime.value <= 30f)
        {
            fill.color = _Red;
        }
    }
}
