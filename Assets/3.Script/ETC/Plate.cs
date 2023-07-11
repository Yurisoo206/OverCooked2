using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Sushi sushi;
    public PlayerControll player;
    private GameObject workTopCheck;

    private int preChildcount;
    private bool check = false;


    public bool fish = false;
    public bool prawn = false;

    private void Start()
    {
        sushi = FindObjectOfType<Sushi>();
        player = FindObjectOfType<PlayerControll>();
        workTopCheck = GetComponent<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !check)
        {
            workTopCheck = other.gameObject;

            Transform parentTransform = workTopCheck.transform;
            int childCount = parentTransform.childCount;

            preChildcount = childCount;
            if (preChildcount < 1 && other.gameObject == player.isWorkTop2)
            {
                check = true;
                gameObject.transform.SetParent(null);
                player.isPlate = false;

                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
            player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name &&
            !player.ishand
           )
        {
            check = false;
            gameObject.transform.SetParent(null);
            player.isPlate = true;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Cook") && Input.GetKeyDown(KeyCode.Space) && player.isPlate )
        {

            gameObject.transform.SetParent(null);
            transform.SetParent(player.isWorkTop2.gameObject.transform);
            transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            fish = true;
            this.gameObject.layer = 9;
            cookCheck();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !check )
        {
            workTopCheck = other.gameObject;

            Transform parentTransform = workTopCheck.transform;
            int childCount = parentTransform.childCount;

            preChildcount = childCount;
            if (preChildcount < 1 && other.gameObject == player.isWorkTop2)
            {
                check = true;
                gameObject.transform.SetParent(null);
                player.isPlate = false;

                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
            player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name &&
            !player.ishand
           )
        {
            check = false;
            gameObject.transform.SetParent(null);
            player.isPlate = true;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Sushi") && Input.GetKeyDown(KeyCode.Space) && player.isPlate)
        {
            gameObject.transform.SetParent(null);
            transform.SetParent(player.isWorkTop2.gameObject.transform);
            transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            fish = true;
            this.gameObject.layer = 9;
            cookCheck();
        }

        if (other.CompareTag("Prawn") && Input.GetKeyDown(KeyCode.Space) && player.isPlate)
        {
            gameObject.transform.SetParent(null);
            transform.SetParent(player.isWorkTop2.gameObject.transform);
            transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            fish = true;
            this.gameObject.layer = 9;
            cookCheck();
        }
    }

    private void cookCheck()
    {
        if (fish)
        {
            this.gameObject.tag = "SushiCook";
        }
        if (prawn)
        {
            this.gameObject.tag = "PrawnCook";
        }
    }
}
