using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime = 150f;
    public Text text_Timer;

    int min;
    float sec;

    void Update()
    {
        if (LimitTime >= 0)
        {
            LimitTime -= Time.deltaTime;
            if (LimitTime >= 60f)
            {
                min = (int)LimitTime / 60;
                sec = LimitTime % 60;
                if (sec >= 10)
                {
                    text_Timer.text = "0" + min + ":" + (int)sec;
                }

                if (sec < 10)
                {
                    text_Timer.text = "0" + min + ":0" + (int)sec;
                }

            }

            if (LimitTime < 60f)
            {
               

                if (sec >= 10)
                {
                    text_Timer.text = "00:" + (int)LimitTime;
                }

                if (sec < 10)
                {
                    text_Timer.text = "00:" + (int)LimitTime;
                }
            }

            if (LimitTime < 10f)
            {
                text_Timer.text = "00:0" + (int)LimitTime;
            }

        }
        
    }
}
