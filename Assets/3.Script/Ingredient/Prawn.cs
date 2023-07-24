using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prawn : MonoBehaviour
{
    public PlayerControll player;

    public GameObject prawn_prefed;
    public GameObject prawnFire;

    public bool isplate = false;
    public bool isCooking = false;//workTop �ø��� ��
    public bool isCook = false;//������ ���ΰ�
    public bool isfall = false;//�� �ٴڿ� �δ� ��
    public bool isfallCheck = false;

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
        if (isfallCheck)
        {
            isfallCheck = false;
        }
        else if (gameObject.transform.root.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && !player.isCollision && !isfall && !isfallCheck && !isCooking)
        {
            Debug.Log("�ϴ� true");
            isfall = true;
            gameObject.transform.SetParent(null);
            gameObject.AddComponent<Rigidbody>();
        }
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
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                isCooking = true;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && !isCooking)
        {
            isfall = false;
            isfallCheck = true;
            Debug.Log("�ϴ� false");

            if (gameObject.transform.parent != null)
            {
                if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && !isfall)
                {
                    Debug.Log(gameObject.GetComponentsInParent<Transform>()[1].name);
                    gameObject.transform.SetParent(null);
                }
            }
            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
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
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                isCooking = true;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && !isCooking)
        {
            isfall = false;
            isfallCheck = true;

            if (gameObject.transform.parent != null)
            {
                if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && !isfall)
                {
                    Debug.Log(gameObject.GetComponentsInParent<Transform>()[1].name);
                    gameObject.transform.SetParent(null);

                }
            }
            check = false;
            transform.SetParent(other.gameObject.transform);
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.GetComponentsInChildren<Transform>()[1].transform.rotation;

            Destroy(GetComponent<Rigidbody>());

        }
        if (other.CompareTag("Player") && player.cookend && !isfall)//������ ��
        {
            if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name)// �̷��� if���� �� �� ���� ������ �ٴڿ� ������ ���� ������ �ϱ� ���ؼ�
            {
                player.cookend = false;
                prawnFire = Instantiate(prawn_prefed, gameObject.transform.position, gameObject.transform.rotation);
                prawnFire.transform.SetParent(gameObject.GetComponentsInParent<Transform>()[1].transform);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Player") && player.isCook && !isfall)//������ ��
        {
            if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name)
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

        if (other.CompareTag("Player") && !player.isCook)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            //Debug.Log("��ƼŬ �� ����");
        }
    }
}
