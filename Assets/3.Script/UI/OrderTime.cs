using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTime : MonoBehaviour
{
    public Score score;
    public Orderlist orderlist;

    public DishCoinUI dishCoinUI;

    private float timerDuration = 15; // 각 타이머의 지속 시간


    public Slider[] slider = new Slider[3];

    private float currentTime;

    private int num = 0;

    public AudioSource audioSource;
    public AudioClip removeAudio;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timerDuration = 10;

        dishCoinUI = FindObjectOfType<DishCoinUI>();
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
            score.tip = 0;
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

            audioSource.clip = removeAudio;
            audioSource.Play();
        }

        yield break;
    }

    private void OnDisable()
    {
        if (num == 0)
        {
            score.score += 50;
            score.tip++;
            dishCoinUI.dishcoinActive = true;
            //Debug.Log("팁 확인" + dishCoinUI.dishcoinActive);
        }
        else if (num == 1)
        {
            score.score += 30;
            score.tip++;
            score.score += score.tipCoin;
            dishCoinUI.dishcoinActive = true;
            //Debug.Log("팁 확인" + dishCoinUI.dishcoinActive);
        }
        else if (num == 2)
        {
            score.score += 20;
            score.tip = 0;
        }

    }
}
 