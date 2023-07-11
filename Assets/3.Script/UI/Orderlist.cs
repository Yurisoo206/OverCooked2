using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderlist : MonoBehaviour
{
    public CompleteDish dish;
    public Transform respawn;

    public GameObject order1;
    public GameObject order2;
    public GameObject order3;
    public GameObject order4;
    public GameObject order5;//Transform으로 바꿔라

    public GameObject sheet1;
    public GameObject sheet2;

    public GameObject randomSheet;

    public GameObject order;


    public GameObject sheet1_prefed;
    public GameObject sheet2_prefed;

    List<GameObject> orderList = new List<GameObject>();//그 생성
    public GameObject[] setList;
    
    public int orderNum = 5;

    private int num = 0;

    public bool check = false;

    private void Start()
    {
        dish = FindObjectOfType<CompleteDish>();
        setList = new GameObject[3];

        setList[0] = order1;
    }


    void Update()
    {
        StartOrder();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sheet1 = sheet1_prefed;
            sheet2 = sheet2_prefed;
            RandomOrder();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            OrderClear();
        }

    }

    public void StartOrder()
    {
        sheet1.transform.position = Vector3.Lerp(sheet1.transform.position, order1.transform.position, 0.2f);
        sheet2.transform.position = Vector3.Lerp(sheet2.transform.position, order2.transform.position, 0.2f);
        if (num < 1)
        {
            orderList.Add(sheet1);
            orderList.Add(sheet2);
            num++;
        }
    }

    public void RandomSheet()
    {
        int randomOrder = Random.Range(1, 3);

        if (randomOrder == 1)
        {
            randomSheet = sheet1;
        }
        else if (randomOrder == 2)
        {
            randomSheet = sheet2;
        }
    }

    public void RandomOrder()
    {
        RandomSheet();
        orderList.Add(randomSheet);
        order = Instantiate(randomSheet, respawn.position, respawn.rotation);
        order.transform.SetParent(gameObject.transform);
        for (int i = 0; i < orderList.Count; i++)
        {        
            Debug.Log("배열 확인 : " + orderList[i].name);
        }
    }
     
    public void OrderClear()
    {
        if (check)
        {
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i] == sheet1)
                {
                    Debug.Log("이거 삭제해" + orderList[i].name);
                    orderList.RemoveAt(i);

                    break;
                }
            }

            check = false;
        }
    }                                                                           
}
