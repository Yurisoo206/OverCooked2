using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrawnFire : MonoBehaviour
{
    public PlayerControll player;

    public bool isplate = false;
    public bool isCooking = false;//workTop ¿Ã¸®´Â °Å
    public bool isfall = false;//°Á ¹Ù´Ú¿¡ µÎ´Â ¿ë

    public GameObject UI_Prefad;
    private GameObject UI;
    private GameObject workTopCheck;
    private GameObject plateTag;

    private int preChildcount;
    private bool check = false;

    private void Start()
    {
        UI = Instantiate(UI_Prefad, transform.position, Quaternion.identity, transform);
        UI.transform.rotation = transform.rotation.normalized;
        player = FindObjectOfType<PlayerControll>();
        workTopCheck = GetComponent<GameObject>();
    }

    private void Update()
    {
        if (gameObject.transform.root.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && !player.isCollision && gameObject != isfall)
        {
            Debug.Log(player.cookend);
            isfall = true;
            Debug.Log("¶³±Å");
            gameObject.transform.SetParent(null);
            gameObject.AddComponent<Rigidbody>();
        }
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

            plateTag = gameObject.GetComponentsInParent<Transform>()[2].gameObject;
            plateTag.layer = 9;
            plateTag.tag = "PrawnCook";
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

            plateTag = gameObject.GetComponentsInParent<Transform>()[2].gameObject;
            plateTag.layer = 9;
            plateTag.tag = "PrawnCook";
        }

        
    }
}
