using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public PlayerControll playerControll;
    public GameObject timer;

    public bool isplate = false;
    public bool isCooking = false;

    private void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
        timer = FindObjectOfType<GameObject>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate)
        {

            gameObject.transform.SetParent(null);
            transform.SetParent(playerControll.isWorkTop2.gameObject.transform);
            transform.position = playerControll.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            Debug.Log("���� ��ġ" + playerControll.isWorkTop2);
            isCooking = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�̸��� ����" + gameObject.name);
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
            Debug.Log("����");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            isplate = true;
        }

        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate)//��������
        {
            gameObject.transform.SetParent(null);

            transform.SetParent(playerControll.isWorkTop2.gameObject.transform);
            transform.position = playerControll.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            Debug.Log("���� ��ġ"+ playerControll.isWorkTop2);
            isCooking = true;
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) )
        {
            Debug.Log(playerControll.isWorkTop2);
            Debug.Log("�̸��� ����" + gameObject.GetComponentsInParent<Transform>()[3].name);
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))//������
        {
            timer.SetActive(true);
        }

        if (other.CompareTag("ChppingBoard") && !isCooking)
        {
            isCooking = true;
            Debug.Log("�ϴ� : " + other.gameObject.name);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            Debug.Log("���ÿ��� �ƿ�");
            isplate = false;
        }
        if (other.CompareTag("ChppingBoard") && isCooking)
        {
            isCooking = false;
            Debug.Log("���� : " + other.gameObject.name);
        }
    }

    private void Put()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerControll.getCook = false;
            gameObject.transform.SetParent(null);
            
        }
    }

}
