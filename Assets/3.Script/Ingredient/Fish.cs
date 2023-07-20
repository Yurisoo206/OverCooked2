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
    public bool isCooking = false;//workTop �ø��� ��
    public bool isCook = false;//������ ���ΰ�
    //private bool isCollision = false;//�ƹ��͵� ���� �� �� �� �� �� ����
    public bool isfall = false;//�� �ٴڿ� �δ� ��

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
            Debug.Log("����");
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
        //    //Debug.Log("�������� " + gameObject.transform.root);
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
        //    //Debug.Log("�������� " + gameObject.transform.root);
        //}

        if (other.CompareTag("Player") && player.cookend && !isfall )//������ ��
        {
            if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name)
            {
                player.cookend = false;
                sushi = Instantiate(sushi_prefed, gameObject.transform.position, gameObject.transform.rotation);
                sushi.transform.SetParent(gameObject.GetComponentsInParent<Transform>()[1].transform);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Player") && player.isCook && !isfall)//������ ��
        {
            if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name )
            {
                //Debug.Log("��ƼŬ ������ ����");
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
        //    Debug.Log("���� ����");
        //}

        if (other.CompareTag("Player") && !player.isCook)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            //Debug.Log("��ƼŬ �� ����");
        }
    }



}
