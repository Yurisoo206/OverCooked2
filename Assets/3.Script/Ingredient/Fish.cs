using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public PlayerControll player;

    public GameObject sushi_prefed;
    public GameObject sushi;

    public bool isplate = false;
    public bool isCooking = false;//workTop 올리는 거
    public bool isCook = false;//다지는 중인거
    //private bool isCollision = false;//아무것도 접촉 안 할 때 알 기 위해
    public bool isfall = false;//걍 바닥에 두는 용

    private GameObject workTopCheck;

    private int preChildcount;
    private bool check = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        workTopCheck = GetComponent<GameObject>();
    }

    private void Update()
    {
        if (gameObject.transform.root.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && !player.isCollision)
        {
            
            Debug.Log(player.cookend);
            isfall = true;
            Debug.Log("떨궈");
            gameObject.transform.SetParent(null);
            
        }
    }

    public void OnTriggerEnter(Collider other)
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
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                isCooking = true;
            }
        }

        //if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && player.ishand)
        //{
        //    check = false;
        //    gameObject.transform.SetParent(null);
        //    transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
        //    transform.SetParent(other.gameObject.transform);
        //    //Debug.Log("떨어져라 " + gameObject.transform.root);
        //}
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
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                isCooking = true;
            }
        }
        //if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) &&
        //    player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && !player.ishand 
        //    )
        //{
            
        //    check = false;
        //    gameObject.transform.SetParent(null);
        //    transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
        //    transform.SetParent(other.gameObject.transform);
        //    //Debug.Log("떨어져라 " + gameObject.transform.root);
        //}

        if (other.CompareTag("Player") && player.cookend && !isfall )//다지기 끝
        {
            if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name)
            {
                player.cookend = false;
                sushi = Instantiate(sushi_prefed, gameObject.transform.position, gameObject.transform.rotation);
                sushi.transform.SetParent(gameObject.GetComponentsInParent<Transform>()[1].transform);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Player") && player.isCook && !isfall)//다지기 중
        {
            if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name )
            {
                //Debug.Log("파티클 실행할 예정");
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            
        }

        if (other.CompareTag("ChppingBoard") && !isCooking)
        {
            isCooking = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("WorkTop"))
        //{
        //    isCollision = false;
        //    Debug.Log("인지 포기");
        //}

        if (other.CompareTag("Player") && !player.isCook)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            //Debug.Log("파티클 끌 예정");
        }
    }



}
