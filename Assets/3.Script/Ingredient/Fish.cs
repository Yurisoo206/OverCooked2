using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public Rigidbody rd;
    public PlayerControll player;

    public GameObject sushi_prefed;
    public GameObject sushi;

    public bool isplate = false;
    public bool isCooking = false;//workTop 올리는 거
    public bool isCook = false;//다지는 중인거
    public bool isfall = false;//바닥에 두는 용
    public bool isfallCheck = false;
 

    private GameObject workTopCheck;

    private int preChildcount;
    private bool check = false;

    public AudioSource audioSource;
    public AudioClip pickUpAudio;
    public AudioClip putDownAudio;

    public AudioClip cookOnAudio;



    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        workTopCheck = GetComponent<GameObject>();
        rd = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isfallCheck)
        {
            isfallCheck = false;
        }
        else if (gameObject.transform.root.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && !player.isCollision && !isfall && !isfallCheck && !isCooking)
        {
            audioSource.clip = putDownAudio;
            audioSource.Play();
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

                audioSource.clip = putDownAudio;
                audioSource.Play();

                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                isCooking = true;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand )
        {
            isfall = false;
            isfallCheck = true;

            Destroy(GetComponent<Rigidbody>());
            audioSource.clip = pickUpAudio;
            audioSource.Play();
            if (gameObject.transform.parent != null)
            {
                if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && !isfall && isCook)
                {
                    isCooking = false;
                    Debug.Log(gameObject.GetComponentsInParent<Transform>()[1].name);
                    gameObject.transform.SetParent(null);

                }
            }
            else if (gameObject.transform.parent == null)
            {
                isCooking = false;
                check = false;
                transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
                transform.SetParent(other.gameObject.transform);
            }

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
                audioSource.clip = putDownAudio;
                audioSource.Play();

                check = true;
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
                isCooking = true;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand)
        {
            isfall = false;
            isfallCheck = true;

            Destroy(GetComponent<Rigidbody>());

            audioSource.clip = pickUpAudio;
            audioSource.Play();

            if (gameObject.transform.parent != null)
            {
                if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && !isfall && !isCook)
                {
                    isCooking = false;
                    gameObject.transform.SetParent(null);
                }
            }
            else if (gameObject.transform.parent == null)
            {
                isCooking = false;
                check = false;
                transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
                transform.SetParent(other.gameObject.transform);
            }

        }

        if (other.CompareTag("Player") && player.cookend && !isfall )//다지기 끝
        {
            if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name)// 이렇게 if문을 한 번 빼준 이유는 바닥에 있을때 오류 방지를 하기 위해서
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
                audioSource.clip = cookOnAudio;
                audioSource.loop = true;
                //Debug.Log("파티클 실행할 예정");
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                isCook = true;
            }
            
        }

        if (other.CompareTag("ChppingBoard") && !isCooking )
        {
            isCooking = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player") && !player.isCook)
        {
            audioSource.clip = cookOnAudio;
            audioSource.loop = false;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            //Debug.Log("파티클 끌 예정");
        }
        if (other.CompareTag("ChppingBoard"))
        {
            isCooking = false;
        }
    }



}
