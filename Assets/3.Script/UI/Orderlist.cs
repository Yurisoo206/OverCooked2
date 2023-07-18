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

    
    public GameObject OrderSheet;
    
    public GameObject sheet1;
    public GameObject sheet2;

    public GameObject randomSheet;

    public GameObject order;

    public GameObject sheet1_prefed;
    public GameObject sheet2_prefed;

    List<GameObject> orderList = new List<GameObject>();//그 생성
    public GameObject[] setList;

    private int num = 0;
    private int numcheck = 0;//주문서에 없는 메뉴를 제출 했는지 확인하기 위해

    public int completeDish = 0;

    public bool check = false;
    public bool ordersheetCheck = false;

    private float time = 0f;
    private bool timecheck = true;

    //일단 sheet 생성시 받아갈 위치 
    public GameObject sheetPos;
    

    private void Start()
    {
        dish = FindObjectOfType<CompleteDish>();
        setList = new GameObject[5];
        sheet1 = sheet1_prefed;
        sheet2 = sheet2_prefed;
    }

    void Update()
    {
        StartOrder();
        if (time < 150f)
        {
            time += Time.deltaTime;
            if ((int)time%20 == 1 && timecheck)
            {
                Debug.Log("자자 주문 들어옵니다 아 씨 냉모밀 먹고 싶다");
                RandomOrder();
                timecheck = false;
            }


            if ((int)time % 10 == 2 && !timecheck)
            {
                timecheck = transform;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RandomOrder();
        }
        if (dish.check || ordersheetCheck)
        {
            Debug.Log("설마 되는 건가 두그두그두그");
            OrderClear();
            dish.check = false;
            if (orderList.Count <= 2)
            {
                RandomOrder();
            }
            
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

    public void StartOrder()
    {
        if (num < 1)
        {
            RandomOrder();
            num++;
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
        
        if (completeDish == 1)
        {
            OrderSheet = sheet1;
        }
        else if (completeDish == 2)
        {
            OrderSheet = sheet2;
        }

        for (int i = 0; i < orderList.Count; i++)
        {
            
            if (orderList[i].tag == OrderSheet.tag)
            {
                Destroy(setList[i].gameObject);
                orderList.RemoveAt(i); 

                break;
            }
            else
            {
                numcheck++;
            }
        }

        for (int i = 0; i < orderList.Count; i++)
        {
            if (setList[i] != orderList[i])
            {
                setList[i] = setList[i + 1];
                setList[i + 1] = null;
            }
        }

        for (int i = 0; i < orderList.Count; i++)
        {
            if (setList[i] == orderList[0])
            {
                sheetPos = order1;
                setList[i].transform.position = sheetPos.transform.position;
            }
            else if (setList[i] == orderList[1])
            {
                sheetPos = order2;
                setList[i].transform.position = sheetPos.transform.position;
            }
            else if (setList[i] == orderList[2])
            {
                sheetPos = order3;
                setList[i].transform.position = sheetPos.transform.position;
            }
            else if (setList[i] == orderList[3])
            {
                sheetPos = order4;
                setList[i].transform.position = sheetPos.transform.position;
            }
            else if (setList[i] == orderList[4])
            {
                sheetPos = order5;
                setList[i].transform.position = sheetPos.transform.position;
            }
        }

        if (numcheck == orderList.Count)
        {
            Debug.Log("뭐야 왜 주문 안한거 줌? 별점 1점 드립니다.");
        }

        completeDish = 0;
        numcheck = 0;
        ordersheetCheck = false;
    }
}
