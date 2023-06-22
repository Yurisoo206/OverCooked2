using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
    public PlayerControll playerComtroll;
    private GameObject player_contact;

    public bool isplate = false;

    private void Start()
    {
        playerComtroll = FindObjectOfType<PlayerControll>();
        player_contact = GetComponent<GameObject>();
    }

    private void Update()
    {
        player_contact = playerComtroll.isWorkTop;
    }

    private void Put()//스시 내려놓는거
    {
        if (player_contact != null && Input.GetKeyDown(KeyCode.Space) && playerComtroll.ishand)
        {
            gameObject.transform.SetParent(null);
            transform.position = player_contact.GetComponentsInParent<Transform>()[2].position;
            Debug.Log(playerComtroll.isWorkTop.GetComponentsInParent<Transform>()[2].name);
        }
        if (player_contact == null)
        {
            player_contact = null;
        }
        
    }



  
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !isplate && !playerComtroll.ishand)
        {
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[1].position;
            Debug.Log(other.gameObject.GetComponentsInChildren<Transform>()[1].name);

            transform.SetParent(other.gameObject.transform);
            playerComtroll.ishand = true;
        }

        if (other.CompareTag("Plate") && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.SetParent(null);
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[0].position;
            Debug.Log(playerComtroll.ishand);
            transform.SetParent(other.gameObject.transform);
            isplate = true;
            playerComtroll.ishand = false;

        }

        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space))
        {

            gameObject.transform.SetParent(null);
            transform.position = other.gameObject.GetComponentsInParent<Transform>()[2].position;
            Debug.Log("스시가 붙는겨!");
            playerComtroll.ishand = false;
        }

        

        
    }
}
