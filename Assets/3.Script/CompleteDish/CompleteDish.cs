using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteDish : MonoBehaviour
{
    public LayerMask layerMask;
    public PlayerControll player;
    public Orderlist orderlist;

    public GameObject workTop;

    public GameObject dish;
    public GameObject complete;
    public GameObject attach;

    public GameObject respawn;

    void Start()
    {
        workTop = transform.GetComponentsInChildren<Transform>()[1].transform.gameObject;
        player = FindObjectOfType<PlayerControll>();
        orderlist = FindObjectOfType<Orderlist>();
    }

    public void Check()
    {
        RaycastHit rayobject;

        if (Physics.Raycast(transform.position, transform.up, out rayobject, 6f, layerMask))
        {
            Debug.Log("이건 플러스");
            complete = dish;
            orderlist.check = true;
        }

        else
        {
            Debug.Log("이건 마이너스");
        }
        Debug.DrawRay(transform.position, transform.up * 6f, Color.black);
        player.isPlate = false;
        Destroy(dish, 2f);
        
        //dish.transform.position = respawn.transform.position;//여기에 그릇 생성
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Prawn") &&  other.CompareTag("Sushi") && Input.GetKeyDown(KeyCode.Space) && player.isWorkTop2 == workTop )
        if (other.CompareTag("Plate") && Input.GetKeyDown(KeyCode.Space) && player.isWorkTop2 == workTop)
        {
            dish = other.gameObject;
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.SetParent(attach.transform);
            other.gameObject.transform.position = attach.transform.position;
            Check();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plate") && Input.GetKeyDown(KeyCode.Space) && player.isWorkTop2 == workTop)
        {
            dish = other.gameObject;
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.SetParent(attach.transform);
            other.gameObject.transform.position = attach.transform.position;

            Debug.Log("Prawn : " + dish.name);
            Check();
        }
    }

}
