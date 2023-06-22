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
            Debug.Log("접시에 장착");
            isplate = true;
        }

        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate)
        {
            gameObject.transform.SetParent(null);
            transform.position = other.gameObject.GetComponentsInParent<Transform>()[2].position;
            
            Debug.Log(other.gameObject.GetComponentsInParent<Transform>()[2].name);
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))//다지기
        {
            timer.SetActive(true);
            //gameObject.GetComponentsInChildren<GameObject>()[0].SetActive(true);
            Debug.Log("잘되는 건가");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            Debug.Log("접시에서 아웃");
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
