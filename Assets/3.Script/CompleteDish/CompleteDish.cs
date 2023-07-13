using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteDish : MonoBehaviour
{
    public LayerMask layerMask;
    public PlayerControll player;
    public Orderlist orderlist;
    public RespawnPlate respawnPlate;

    public GameObject workTop;

    public GameObject dish;
    
    public GameObject attach;

    public Score score;


    public bool check = false;//�ֹ� ����


    void Start()
    {
        workTop = transform.GetComponentsInChildren<Transform>()[1].transform.gameObject;
        player = FindObjectOfType<PlayerControll>();
        orderlist = FindObjectOfType<Orderlist>();
        respawnPlate = FindObjectOfType<RespawnPlate>();
        score = FindObjectOfType<Score>();
    }

    public void Check()
    {
        RaycastHit rayobject;

        if (Physics.Raycast(transform.position, transform.up, out rayobject, 6f, layerMask))
        {
            orderlist.check = true;

            if (dish.tag == "SushiCook")
            {
                orderlist.completeDish = 1;
                score.score += 28;
            }
            else if (dish.tag == "PrawnCook")
            {
                orderlist.completeDish = 2;
                score.score += 30;
            }
            check = true;
            
        }

        else
        {
            Debug.Log("�̰� ���̳ʽ�");
        }
        Debug.DrawRay(transform.position, transform.up * 6f, Color.black);
        player.isPlate = false;
        respawnPlate.respawnCheck = true;
        Destroy(dish, 2f);

        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SushiCook") && Input.GetKeyDown(KeyCode.Space) && player.isWorkTop2 == workTop)
        {
            dish = other.gameObject;
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.SetParent(attach.transform);
            other.gameObject.transform.position = attach.transform.position;

            Check();
        }

        if (other.CompareTag("PrawnCook") && Input.GetKeyDown(KeyCode.Space) && player.isWorkTop2 == workTop)
        {
            dish = other.gameObject;
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.SetParent(attach.transform);
            other.gameObject.transform.position = attach.transform.position;

            Check();
        }
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
        if (other.CompareTag("SushiCook") && Input.GetKeyDown(KeyCode.Space) && player.isWorkTop2 == workTop)
        {
            dish = other.gameObject;
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.SetParent(attach.transform);
            other.gameObject.transform.position = attach.transform.position;

            Check();
        }

        if (other.CompareTag("PrawnCook") && Input.GetKeyDown(KeyCode.Space) && player.isWorkTop2 == workTop)
        {
            dish = other.gameObject;
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.SetParent(attach.transform);
            other.gameObject.transform.position = attach.transform.position;

            Check();
        }
        if (other.CompareTag("Plate") && Input.GetKeyDown(KeyCode.Space) && player.isWorkTop2 == workTop)
        {
            dish = other.gameObject;
            other.gameObject.transform.SetParent(null);
            other.gameObject.transform.SetParent(attach.transform);
            other.gameObject.transform.position = attach.transform.position;

            Check();
        }
    }

}
