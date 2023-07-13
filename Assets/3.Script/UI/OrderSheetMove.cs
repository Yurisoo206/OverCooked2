using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSheetMove : MonoBehaviour
{
    public Orderlist orderlist;

    private GameObject test;

    void Start()
    {
        orderlist = FindObjectOfType<Orderlist>();
        test = GetComponent<GameObject>();

    }

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, orderlist.sheetPos.transform.position, 0.2f);
    }


    public void SavePos()
    {
        this.test = orderlist.sheetPos;

    }
}
