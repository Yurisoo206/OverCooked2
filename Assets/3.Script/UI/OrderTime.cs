using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTime : MonoBehaviour
{
    public Score score;
    public Orderlist orderlist;

    public DishCoinUI dishCoinUI;

    private float timerDuration = 20; // 각 타이머의 지속 시간


    public Slider[] slider = new Slider[3];

    private float currentTime;

    private int num = 0;

    public AudioSource audioSource;
    public AudioClip removeAudio;

    public Image slider2_fill;
    public Image slider3_fill;

    Color _Red;
    Color _Orange;


    private void Start()
    {
        _Red = new Color(1, 0, 0, 1);
        _Orange = new Color(1, 0.6f, 0, 1);

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
            if (i == 1)
            {
                slider2_fill.color = _Orange;
                slider3_fill.color = _Orange;
            }

            if (i == 2)
            {
                slider2_fill.color = _Red;
                slider3_fill.color = _Red;
            }

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
                orderlist.completeDish = 2;
                orderlist.ordersheetCheck = true;
                audioSource.clip = removeAudio;
                audioSource.Play();
            }
            else if (gameObject.transform.tag == "Sushi")
            {
                orderlist.completeDish = 1;
                orderlist.ordersheetCheck = true;
                audioSource.clip = removeAudio;
                audioSource.Play();
            }

            
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
 