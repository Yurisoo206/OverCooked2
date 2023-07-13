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
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
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

        if (other.CompareTag("Sushi"))
        {
            GameObject cook = other.gameObject;
            if (cook.GetComponentsInParent<Transform>()[1].name == player.isWorkTop2.name && Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                fish = true;
                this.gameObject.layer = 9;
                gameObject.tag = "SushiCook";
            }
        }
        if (other.CompareTag("Prawn"))
        {
            GameObject cook = other.gameObject;
            if (cook.GetComponentsInParent<Transform>()[1].name == player.isWorkTop2.name && Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                fish = true;
                this.gameObject.layer = 9;
                gameObject.tag = "PrawnCook";
            }
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
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
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

        if (other.CompareTag("Sushi"))
        {
            GameObject cook = other.gameObject;
            if (cook.GetComponentsInParent<Transform>()[1].name == player.isWorkTop2.name && Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                fish = true;
                this.gameObject.layer = 9;
                gameObject.tag = "SushiCook";
            }
        }
        if (other.CompareTag("Prawn"))
        {
            GameObject cook = other.gameObject;
            if (cook.GetComponentsInParent<Transform>()[1].name == player.isWorkTop2.name && Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                fish = true;
                this.gameObject.layer = 9;
                gameObject.tag = "SushiCook";
            }
        }
    }

}
