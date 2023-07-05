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
    public bool isCooking = false;//workTop 올리는 거
    public bool isCook = false;//다지는 중인거


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
            Debug.Log("그릇이라고");
            isplate = true;
        }   

        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate)//내려놓기
        {
            gameObject.transform.SetParent(null);
            transform.SetParent(playerControll.isWorkTop2.gameObject.transform);
            transform.position = playerControll.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            Debug.Log("현재 위치" + playerControll.isWorkTop2.name);
            Debug.Log("현재 위치" + gameObject.GetComponentsInParent<Transform>()[1].name);
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
            
            )//다지기
        {
            playerControll.cookend = false;
            sushi = Instantiate(sushi_prefed, gameObject.transform.position, gameObject.transform.rotation);
            sushi.transform.SetParent(gameObject.GetComponentsInParent<Transform>()[1].transform);
            Debug.Log("이제 여기로 들어가라 : " + gameObject.GetComponentsInParent<Transform>()[1].name );
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
            Debug.Log("접시에서 아웃");
            isplate = false;
        }
        if (other.CompareTag("ChppingBoard") && isCooking)
        {
            isCooking = false;
            Debug.Log("나감 : " + other.gameObject.name);
        }
    }
}
