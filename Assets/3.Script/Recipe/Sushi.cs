using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
    public PlayerControll playerControll;
    public Worktop worktop;
    private GameObject workTop_contact;
    private GameObject workTop_contact2;

    public bool isplate = false;

    private void Start()
    {
        workTop_contact  = FindObjectOfType<GameObject>();
        workTop_contact2 = FindObjectOfType<GameObject>();
        playerControll = FindObjectOfType<PlayerControll>();
    }

    private void Update()
    {
        workTop_contact  = playerControll.preWorkTop;
        workTop_contact2 = playerControll.preWorkTop;
    }

    private void Put()//스시 내려놓는거
    {
        if (workTop_contact != null )
        {
            gameObject.transform.SetParent(null);
            transform.position = workTop_contact.GetComponent<Transform>().position;
            Debug.Log("이게 그 ray 쓴거 : " + workTop_contact.name);
        }
        if (workTop_contact2 != null && workTop_contact == null)
        {
            gameObject.transform.SetParent(null);
            transform.position = workTop_contact2.GetComponent<Transform>().position;
            Debug.Log(workTop_contact2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space))//스시 놓기
        {
            if (workTop_contact != null)
            {
                gameObject.transform.SetParent(null);
                transform.position = workTop_contact.GetComponent<Transform>().position;
                Debug.Log("이게 그 ray 쓴거 : " + workTop_contact.name);
            }
            if (workTop_contact2 != null && workTop_contact == null)
            {
                gameObject.transform.SetParent(null);
                transform.position = workTop_contact2.GetComponent<Transform>().position;
                Debug.Log(workTop_contact2);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space))//스시 놓기
        {
            if (workTop_contact != null)
            {
                gameObject.transform.SetParent(null);
                transform.position = workTop_contact.GetComponent<Transform>().position;
                Debug.Log("이게 그 ray 쓴거 : " + workTop_contact.name);
            }
            if (workTop_contact2 != null && workTop_contact == null)
            {
                gameObject.transform.SetParent(null);
                transform.position = workTop_contact2.GetComponent<Transform>().position;
                Debug.Log(workTop_contact2);
            }
        }
    }
}
