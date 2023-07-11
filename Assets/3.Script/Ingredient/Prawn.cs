using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prawn : MonoBehaviour
{
    public PlayerControll player;

    public GameObject prawn_prefed;
    public GameObject prawnFire;

    public bool isplate = false;
    public bool isCooking = false;//workTop 올리는 거
    public bool isCook = false;//다지는 중인거

    private GameObject workTopCheck;

    private int preChildcount;
    private bool check = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        workTopCheck = GetComponent<GameObject>();
    }

    public void OnTriggerEnter(Collider other)
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
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                isCooking = true;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
            player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && !player.ishand
            )
        {
            check = false;
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }
    }

    public void OnTriggerStay(Collider other)
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
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                isCooking = true;
            }
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
            player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && !player.ishand
            )
        {
            check = false;
            gameObject.transform.SetParent(null);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Player") &&
            player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name &&
            player.cookend
            )//다지기
        {
            player.cookend = false;
            prawnFire = Instantiate(prawn_prefed, gameObject.transform.position, gameObject.transform.rotation);
            prawnFire.transform.SetParent(gameObject.GetComponentsInParent<Transform>()[1].transform);
            Destroy(gameObject);
        }

        if (other.CompareTag("ChppingBoard") && !isCooking)
        {
            isCooking = true;
        }
    }
}
