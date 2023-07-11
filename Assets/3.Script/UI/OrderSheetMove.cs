using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSheetMove : MonoBehaviour
{
    public Orderlist orderlist;

    void Start()
    {
        orderlist = FindObjectOfType<Orderlist>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, orderlist.transform.position, 0.2f);
    }
}
