using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Sushi sushi;
    public PlayerControll player;
    private GameObject workTopCheck;
    public CompleteDish completeDish;

    public bool isfall = false;//걍 바닥에 두는 용
    public bool isfallCheck = false;
    public bool isdishCheck = false;

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

    private void Update()
    {
        if (isfallCheck)
        {
            isfallCheck = false;
        }
        else if (gameObject.transform.root.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && !player.isCollision && !isfall && !isfallCheck && !isdishCheck)
        {
            Debug.Log("일단 true");
            isfall = true;
            gameObject.transform.SetParent(null);
            gameObject.AddComponent<Rigidbody>();
        }
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

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && !isfall 
            && player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name)
        {
            isfall = false;
            isfallCheck = true;
            Debug.Log("일단 false");

            Debug.Log(gameObject.GetComponentsInParent<Transform>()[1].name);
            gameObject.transform.SetParent(null);


            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.GetComponentsInChildren<Transform>()[1].transform.rotation;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && isfall)//줍는거
        {
            isfall = false;
            isfallCheck = true;
            Debug.Log("일단 false");

            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.GetComponentsInChildren<Transform>()[1].transform.rotation;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
        }

        if (other.CompareTag("Sushi"))
        {
            GameObject cook = other.gameObject;
            if (cook.GetComponentsInParent<Transform>()[1].name == player.isWorkTop2.name && Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
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
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                fish = true;
                this.gameObject.layer = 9;
                gameObject.tag = "PrawnCook";
            }
        }

        if (other.CompareTag("CompleteDish") && gameObject.transform.root.tag == "Player")
        {

            if (other.gameObject.transform.GetChild(0).name == player.isWorkTop2.name)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("제발 실행되어주세요");
                    isfallCheck = true;
                    Destroy(GetComponent<Rigidbody>());
                }
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

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && !isfall
            && player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name)//상에서 가져감
        {

            Debug.Log("일단 false");

            Debug.Log(gameObject.GetComponentsInParent<Transform>()[1].name);
            gameObject.transform.SetParent(null);


            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.GetComponentsInChildren<Transform>()[1].transform.rotation;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && isfall)//줍는거
        {
            isfall = false;
            isfallCheck = true;
            Debug.Log("일단 false");

            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.GetComponentsInChildren<Transform>()[1].transform.rotation;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
        }

        if (other.CompareTag("Sushi") && player.isWorkTop2.name == other.gameObject.transform.GetComponentsInParent<Transform>()[1].name && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("뭔가 이상한디?");
            gameObject.transform.SetParent(null);
            transform.SetParent(player.isWorkTop2.gameObject.transform);
            transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
            fish = true;
            this.gameObject.layer = 9;
            other.gameObject.tag = "SushiCook";
            
        }
        if (other.CompareTag("Prawn"))
        {
            GameObject cook = other.gameObject;
            if (cook.GetComponentsInParent<Transform>()[1].name == player.isWorkTop2.name && Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                fish = true;
                this.gameObject.layer = 9;
                gameObject.tag = "SushiCook";
            }
        }

        if (other.CompareTag("CompleteDish") && gameObject.transform.root.tag == "Player")
        {
            if (other.gameObject.transform.GetChild(0).name == player.isWorkTop2.name)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("제발 실행되어주세요");
                    Destroy(GetComponent<Rigidbody>());
                    isfallCheck = true;
                    isdishCheck = true;

                }


            }
            
        }
    }

}
