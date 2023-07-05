using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public PlayerControll playerControll;

    public GameObject sushi_prefed;
    public GameObject sushi;

    public bool isplate = false;
    public bool isCooking = false;//workTop �ø��� ��
    public bool isCook = false;//������ ���ΰ�


    private void Start()
    {
        playerControll = FindObjectOfType<PlayerControll>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate)
        {
            gameObject.transform.SetParent(null);
            transform.SetParent(playerControll.isWorkTop2.gameObject.transform);
            transform.position = playerControll.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            isCooking = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
            playerControll.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name
            )
        {
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plate") )
        {
            Debug.Log("�׸��̶��");
            isplate = true;
        }   

        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate)//��������
        {
            gameObject.transform.SetParent(null);
            transform.SetParent(playerControll.isWorkTop2.gameObject.transform);
            transform.position = playerControll.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            Debug.Log("���� ��ġ" + playerControll.isWorkTop2.name);
            Debug.Log("���� ��ġ" + gameObject.GetComponentsInParent<Transform>()[1].name);
            isCooking = true;
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
            playerControll.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name
            )
        {
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Player") && 
            playerControll.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name &&
            playerControll.cookend
            
            )//������
        {
            playerControll.cookend = false;
            sushi = Instantiate(sushi_prefed, gameObject.transform.position, gameObject.transform.rotation);
            sushi.transform.SetParent(gameObject.GetComponentsInParent<Transform>()[1].transform);
            Debug.Log("���� ����� ���� : " + gameObject.GetComponentsInParent<Transform>()[1].name );
            Destroy(gameObject);
        }

        if (other.CompareTag("ChppingBoard") && !isCooking)
        {
            isCooking = true;
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
}
