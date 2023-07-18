using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderTime : MonoBehaviour
{
    public Score score;
    public Orderlist orderlist;
    public float timerDuration = 5; // �� Ÿ�̸��� ���� �ð�


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
        Debug.Log("���°��" + gameObject);
        Debug.Log("��ȣ ����" + num);
        // ���� Ÿ�̸��� �ε����� ã��
        int currentIndex = transform.GetSiblingIndex();

        // ���� Ÿ�̸��� �ε����� ���
        nextIndex = currentIndex + 1;
        num++;
        if (nextIndex < transform.parent.childCount-1)
        {
            // ���� Ÿ�̸Ӹ� Ȱ��ȭ��Ŵ
            OrderTime nextTimer = transform.parent.GetChild(nextIndex).GetComponent<OrderTime>();
            nextTimer.enabled = true;
        
        }
        else
        {
            num++;
            Debug.Log("���� ���� ����" + gameObject.transform.parent);
            score.score -= 30;
            if (gameObject.transform.parent.tag == "Prawn")
            {
                Debug.Log("�ϴ� ����");
                orderlist.completeDish = 2;
                orderlist.ordersheetCheck = true;
            }
            else if (gameObject.transform.parent.tag == "Sushi")
            {

                Debug.Log("�ϴ� ����");
                orderlist.completeDish = 1;
                orderlist.ordersheetCheck = true;
            }
        }

    }

    private void OnDisable() 
    {
        if (gameObject.name == "Time")
        {
            Debug.Log("�� ������");
        }
        if (nextIndex == 3)
        {
            Debug.Log("��¦ �Ƽ���");
        }
        if (nextIndex == 4)
        {
            Debug.Log("�ƽ��ƽ� �ߴ�.");
        }
        
    }

    //public void TimerCheck(int num)//Ÿ�̸� ��� �Ұ���
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
                    // Ÿ�̸Ӱ� ������ �� ���� Ÿ�̸Ӹ� �۵���Ŵ
                    ActivateNextTimer();
                    break;
                }
            }
        }

        yield break;
    }
}
