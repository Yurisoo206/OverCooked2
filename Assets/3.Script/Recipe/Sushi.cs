using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
    public PlayerControll player;

    public bool isplate = false;
    public bool isCooking = false;//workTop �ø��� ��

    private GameObject workTopCheck;
    private GameObject plateTag;

    private int preChildcount;
    private bool check = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        workTopCheck = GetComponent<GameObject>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate && !check)
        {
            workTopCheck = other.gameObject;

            Transform parentTransform = workTopCheck.transform;
            int childCount = parentTransform.childCount;

            preChildcount = childCount;
            if (preChildcount < 1 && other.gameObject == player.isWorkTop2)
            {
                check = true;
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                isCooking = true;
            }
            
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
            player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name &&
            !player.isPlate && !isplate
            )
        {
            check = false;
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Plate") && !isplate && Input.GetKeyDown(KeyCode.Space))
        {
            //isplate = true;
            gameObject.transform.SetParent(null);
            transform.SetParent(other.gameObject.GetComponentsInChildren<Transform>()[1].transform);
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.gameObject.GetComponentsInChildren<Transform>()[1].transform.rotation;
            //this.gameObject.layer = 9;
            //this.gameObject.tag = "Sushi";
            Debug.Log(gameObject.GetComponentsInParent<Transform>()[2].name);
            plateTag = gameObject.GetComponentsInParent<Transform>()[2].gameObject;
            plateTag.layer = 9;
            plateTag.tag = "SushiCook";
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate && !check)
        {
            workTopCheck = other.gameObject;

            Transform parentTransform = workTopCheck.transform;
            int childCount = parentTransform.childCount;

            preChildcount = childCount;
            if (preChildcount < 1 && other.gameObject == player.isWorkTop2)
            {
                check = true;
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                isCooking = true;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
            player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && 
            !player.isPlate && !isplate            
            )
        {
            check = false;
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }


        if (other.CompareTag("Plate") && !isplate && Input.GetKeyDown(KeyCode.Space))
        {
            isplate = true;
            gameObject.transform.SetParent(null);
            transform.SetParent(other.gameObject.GetComponentsInChildren<Transform>()[1].transform);
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.gameObject.GetComponentsInChildren<Transform>()[1].transform.rotation;

            Debug.Log(gameObject.GetComponentsInParent<Transform>()[2].name);
            plateTag = gameObject.GetComponentsInParent<Transform>()[2].gameObject;
            plateTag.layer = 9;
            plateTag.tag = "SushiCook";
        }
    }

}
