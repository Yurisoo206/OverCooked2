using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookTime : MonoBehaviour
{
    public PlayerControll playerControll;
    public Slider sliderTime;
    public float LimitTime = 150f;

    private void Start()
    {
        sliderTime = GetComponent<Slider>();
        playerControll = GetComponent<PlayerControll>();
        sliderTime.maxValue = LimitTime;
        sliderTime.value = LimitTime;
    }
    void Update()
    { 
        if (playerControll.isCook)
        {
            Timer();

        }
        
      
    }

    private void Timer()
    {
        LimitTime -= Time.deltaTime;
        if (sliderTime.value > 0.0f)
        {
            sliderTime.value -= Time.deltaTime;
        }
    }

    
}
