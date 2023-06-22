using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public PlayerControll playerComtroll;
    public GameObject timer;

    public bool isplate = false;
    public bool isCooking = false;

    private void Start()
    {
        playerComtroll = FindObjectOfType<PlayerControll>();
        timer = FindObjectOfType<GameObject>();
    }
    private void Update()
    {
        //Put();
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            Debug.Log("���ÿ� ����");
            isplate = true;
        }

        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate)
        {
            gameObject.transform.SetParent(null);
            transform.position = other.gameObject.GetComponentsInParent<Transform>()[2].position;
            
            Debug.Log(other.gameObject.GetComponentsInParent<Transform>()[2].name);
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))//������
        {
            timer.SetActive(true);
            //gameObject.GetComponentsInChildren<GameObject>()[0].SetActive(true);
            Debug.Log("�ߵǴ� �ǰ�");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            Debug.Log("���ÿ��� �ƿ�");
            isplate = false;
        }
    }

    private void Put()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerComtroll.getCook = false;
            gameObject.transform.SetParent(null);
            
        }
    }

}
