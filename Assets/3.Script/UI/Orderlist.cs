using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderlist : MonoBehaviour
{
    public CompleteDish dish;
    public Transform respawn;

    public Transform order1;
    public Transform order2;
    public Transform order3;
    public Transform order4;
    public Transform order5;

    public GameObject sheet1;
    public GameObject sheet2;

    public GameObject randomSheet;

    public GameObject order;
    List<GameObject> orderList = new List<GameObject>();
    public int orderNum = 5;

    private int num = 0;

    public bool check = false;

    private void Start()
    {
        dish = FindObjectOfType<CompleteDish>();
    }


    void Update()
    {
        StartOrder();
        if (Input.GetKeyDown(KeyCode.Q))
        {
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
