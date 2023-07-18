using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTime : MonoBehaviour
{
    public Score score;
    public Orderlist orderlist;
    public float timerDuration = 5; // 각 타이머의 지속 시간


    public Slider[] slider = new Slider[3];
    //private Slider slider02;
    //private Slider slider03;

    private float currentTime;



    private int num = 0;
    int nextIndex;

    private void Start()
    {

        orderlist = FindObjectOfType<Orderlist>();
        score = FindObjectOfType<Score>();
        for (int i = 0; i < 3; i++)
        {
            slider[i].maxValue = timerDuration;
        }
        
        currentTime = timerDuration;

        StartCoroutine(TimeerCheck_co());
    }



    private void ActivateNextTimer()
    {
        Debug.Log("몇번째여" + gameObject);
        Debug.Log("번호 시작" + num);
        // 현재 타이머의 인덱스를 찾음
        int currentIndex = transform.GetSiblingIndex();

        // 다음 타이머의 인덱스를 계산
        nextIndex = currentIndex + 1;
        num++;
        if (nextIndex < transform.parent.childCount-1)
        {
            // 다음 타이머를 활성화시킴
            OrderTime nextTimer = transform.parent.GetChild(nextIndex).GetComponent<OrderTime>();
            nextTimer.enabled = true;
        
        }
        else
        {
            num++;
            Debug.Log("이제 삭제 하자" + gameObject.transform.parent);
            score.score -= 30;
            if (gameObject.transform.parent.tag == "Prawn")
            {
                Debug.Log("일단 새우");
                orderlist.completeDish = 2;
                orderlist.ordersheetCheck = true;
            }
            else if (gameObject.transform.parent.tag == "Sushi")
            {

                Debug.Log("일단 스시");
                orderlist.completeDish = 1;
                orderlist.ordersheetCheck = true;
            }
        }

    }

    private void OnDisable() 
    {
        if (gameObject.name == "Time")
        {
            Debug.Log("열 빠른데");
        }
        if (nextIndex == 3)
        {
            Debug.Log("살짝 아수비");
        }
        if (nextIndex == 4)
        {
            Debug.Log("아슬아슬 했다.");
        }
        
    }

    //public void TimerCheck(int num)//타이머 대신 할거임
    //{
    //    StartCoroutine(TimeerCheck_co(num));


    //}

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
                    currentTime = 0;
                    // 타이머가 끝났을 때 다음 타이머를 작동시킴
                    ActivateNextTimer();
                    break;
                }
            }
        }

        yield break;
    }
}
