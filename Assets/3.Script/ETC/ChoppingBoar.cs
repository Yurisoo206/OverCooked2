using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoar : MonoBehaviour
{
    public PlayerControll player;

    public bool isFood = false;

    GameObject knife = null;
    GameObject ui = null;
    GameObject workTop = null;
    GameObject test = null;

    public LayerMask layerMask;

    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        knife = transform.GetChild(3).gameObject;
        ui = transform.GetChild(4).gameObject;
        workTop = transform.GetComponentsInChildren<Transform>()[1].transform.gameObject;
    }
    private void Update()
    {
        Knife();
    }

    private void Knife()
    {
        if (!player.isCook)
        {
            knife.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && 
            Input.GetKeyDown(KeyCode.E) && 
            workTop.name == player.isWorkTop2.GetComponentsInParent<Transform>()[2].name &&
            !player.isCook
            )
        {
            knife.SetActive(false);
            player.isCook = true;
            player.cookWorkTop = player.isWorkTop2;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && 
            workTop.name == player.isWorkTop2.GetComponentsInParent<Transform>()[2].name &&
            !player.isCook
            )
        {
            RaycastHit rayobject;

            if (Physics.Raycast(transform.position, transform.up, out rayobject, 6f, layerMask))
            {
                ui.SetActive(true);
                knife.SetActive(false);
                player.isCook = true;
                player.cookWorkTop = player.isWorkTop2;
                player.choppingBoar = gameObject;
            }
            Debug.DrawRay(transform.position, transform.up * 6f, Color.black);
        }

        if (other.CompareTag("Player") && player.isCook && player.cookWorkTop.name != player.isWorkTop2.name)
        {
            player.isCook = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.isCook = false;
        }
    }
}
