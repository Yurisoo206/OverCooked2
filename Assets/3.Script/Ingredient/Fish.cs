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
            Debug.Log("현재 위치" + playerControll.isWorkTop2);
            isCooking = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("이름으 뭔디" + gameObject.name);
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
            Debug.Log("집자");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            isplate = true;
        }

        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate)//내려놓기
        {
            gameObject.transform.SetParent(null);

            transform.SetParent(playerControll.isWorkTop2.gameObject.transform);
            transform.position = playerControll.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            Debug.Log("현재 위치"+ playerControll.isWorkTop2);
            isCooking = true;
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) )
        {
            Debug.Log(playerControll.isWorkTop2);
            Debug.Log("이름으 뭔디" + gameObject.GetComponentsInParent<Transform>()[3].name);
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))//다지기
        {
            timer.SetActive(true);
        }

        if (other.CompareTag("ChppingBoard") && !isCooking)
        {
            isCooking = true;
            Debug.Log("일단 : " + other.gameObject.name);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            Debug.Log("접시에서 아웃");
            isplate = false;
        }
        if (other.CompareTag("ChppingBoard") && isCooking)
        {
            isCooking = false;
            Debug.Log("나감 : " + other.gameObject.name);
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
