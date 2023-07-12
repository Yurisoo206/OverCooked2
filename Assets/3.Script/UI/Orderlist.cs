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
    public bool test = false;


    //일단 sheet 생성시 받아갈 위치 
    public GameObject sheetPos;


    private void Start()
    {
        dish = FindObjectOfType<CompleteDish>();
        setList = new GameObject[5];
        
    }

    void Update()
    {
        
        //StartOrder();
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
        //sheet1.transform.position = Vector3.Lerp(sheet1.transform.position, order1.transform.position, 0.2f);
        //sheet2.transform.position = Vector3.Lerp(sheet2.transform.position, order2.transform.position, 0.2f);
        if (num < 1)
        {
            orderList.Add(sheet1);
            orderList.Add(sheet2);

            setList[0] = sheet1;
            setList[1] = sheet2;

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

        if (orderList.Count < 5)
        {
            order = Instantiate(randomSheet, respawn.position, respawn.rotation);
            orderList.Add(order);
            order.transform.SetParent(gameObject.transform);

            for (int i = 0; i < setList.Length; i++)
            {
                if (setList[i] == null)
                {
                    setList[i] = order.gameObject;
                    break;
                }

                Debug.Log("모르겠다고 : " + setList[i].gameObject);
            }

            for (int i = 0; i < orderList.Count; i++)
            {
                if (order == orderList[0])
                {
                    sheetPos = order1;
                    order = setList[0];
                    order.transform.position = sheetPos.transform.position;
                }
                else if (order == orderList[1])
                {
                    sheetPos = order2;
                    order = setList[1];
                    order.transform.position = sheetPos.transform.position;
                }
                else if (order == orderList[2])
                {
                    sheetPos = order3;
                    order = setList[2];
                    order.transform.position = sheetPos.transform.position;
                }
                else if (order == orderList[3])
                {
                    sheetPos = order4;
                    order = setList[3];
                    order.transform.position = sheetPos.transform.position;
                }
                else if (order == orderList[4])
                {
                    sheetPos = order5;
                    order = setList[4];
                    order.transform.position = sheetPos.transform.position;
                }
            }
            check = true;
        }
    }
     
    public void OrderClear()
    {
        for (int i = 0; i < orderList.Count; i++)
        {
            if (orderList[i].tag == sheet1.tag)
            {
                //Debug.Log("이거 삭제해" + orderList[i].name);
                orderList.RemoveAt(i);

                Destroy(setList[i].gameObject);
                
                Debug.Log("이거 삭제해" + setList[i] + i);
                setList[i] = null;
                check = true;
                break;
            }
        }

        for (int i = 0; i < orderList.Count; i++)
        {
            if (setList[i] = null)
            {
                Debug.Log("으어어");
                //Debug.Log("아 지친다 진짜");
                setList[i] = setList[i + 1];
                setList[i + 1] = null;
            }

            Debug.Log("오더" + orderList[i] +i);
        }

        //if (check)
        //{
        //    for (int i = 0; i < orderList.Count; i++)
        //    {
        //        if (setList[i] == orderList[0])
        //        {
        //            sheetPos = order1;
        //            setList[i].transform.position = sheetPos.transform.position;
        //        }
        //        else if (setList[i] == orderList[1])
        //        {
        //            sheetPos = order2;
        //            setList[i].transform.position = sheetPos.transform.position;
        //        }
        //        else if (setList[i] == orderList[2])
        //        {
        //            sheetPos = order3;
        //            setList[i].transform.position = sheetPos.transform.position;
        //        }
        //        else if (setList[i] == orderList[3])
        //        {
        //            sheetPos = order4;
        //            setList[i].transform.position = sheetPos.transform.position;
        //        }
        //        else if (setList[i] == orderList[4])
        //        {
        //            sheetPos = order5;
        //            setList[i].transform.position = sheetPos.transform.position;
        //        }
        //    }

        //    check = false;
        //}

    }
}
