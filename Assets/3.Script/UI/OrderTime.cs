using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTime : MonoBehaviour
{
    public Score score;
    public Orderlist orderlist;
    private float timerDuration = 10; // 각 타이머의 지속 시간


    public Slider[] slider = new Slider[3];

    private float currentTime;

    private int num = 0;


    private void Start()
    {
       
        timerDuration = 10;

        orderlist = FindObjectOfType<Orderlist>();
        score = FindObjectOfType<Score>();
        for (int i = 0; i < 3; i++)
        {
            slider[i].maxValue = timerDuration;
            slider[i].value = timerDuration;
        }
        
        currentTime = timerDuration;

        StartCoroutine(TimeerCheck_co());
    }

    IEnumerator TimeerCheck_co()
    {
        for (int i = 0; i < 3; i++)
        {
            
            while (true)
            {
                currentTime -= Time.deltaTime;
                slider[i].value = currentTime;

                if (currentTime <= 0)
                {
                    currentTime = timerDuration;
                    
                    break;
                }
                yield return null;
            }
            num++;
        }


        if (num > 2)
        {
            score.score -= 30;
            //Debug.Log("코인" + score.score);
            //Debug.Log("타임오버로 사라집니다.");
            if (gameObject.transform.tag == "Prawn")
            {
                //Debug.Log("일단 새우");
                orderlist.completeDish = 2;
                orderlist.ordersheetCheck = true;
            }
            else if (gameObject.transform.tag == "Sushi")
            {

                //Debug.Log("일단 스시");
                orderlist.completeDish = 1;
                orderlist.ordersheetCheck = true;
            }
        }

        yield break;
    }

    private void OnDisable()
    {
        if (num == 0)
        {
            score.score += 28;
            
        }
        else if (num == 1)
        {
            score.score += 20;
            //Debug.Log("점수플러스");
        }
        else if (num == 2)
        {
            score.score += 15;
            //Debug.Log("점수플러스");
        }

    }
}
