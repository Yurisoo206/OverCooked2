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

    public AudioSource audioSource;
    public AudioClip pickUpAudio;
    public AudioClip putDownAudio;

    private void Start()
    {
        sushi = FindObjectOfType<Sushi>();
        player = FindObjectOfType<PlayerControll>();
        workTopCheck = GetComponent<GameObject>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isfallCheck)
        {
            isfallCheck = false;
            isdishCheck = false; 
        }
        else if (gameObject.transform.root.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && !player.isCollision && !isfall && !isfallCheck && !isdishCheck)
        {
            audioSource.clip = putDownAudio;
            audioSource.Play();

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
                audioSource.clip = putDownAudio;
                audioSource.Play();

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

            gameObject.transform.SetParent(null);

            audioSource.clip = pickUpAudio;
            audioSource.Play();

            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.GetComponentsInChildren<Transform>()[1].transform.rotation;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && isfall)//줍는거
        {
            audioSource.clip = pickUpAudio;
            audioSource.Play();

            isfall = false;
            isfallCheck = true;
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
                audioSource.clip = putDownAudio;
                audioSource.Play();
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
                audioSource.clip = putDownAudio;
                audioSource.Play();
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
            isdishCheck = true;
            if (other.gameObject.transform.GetChild(0).name == player.isWorkTop2.name && Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(GetComponent<Rigidbody>());
                isfallCheck = true;
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
                audioSource.clip = putDownAudio;
                audioSource.Play();
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
            audioSource.clip = pickUpAudio;
            audioSource.Play();

            gameObject.transform.SetParent(null);

            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.GetComponentsInChildren<Transform>()[1].transform.rotation;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && isfall)//줍는거
        {
            audioSource.clip = pickUpAudio;
            audioSource.Play();

            isfall = false;
            isfallCheck = true;

            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.GetComponentsInChildren<Transform>()[1].transform.rotation;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
        }

        if (other.CompareTag("Sushi") && player.isWorkTop2.name == other.gameObject.transform.GetComponentsInParent<Transform>()[1].name && Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = putDownAudio;
            audioSource.Play();

            gameObject.transform.SetParent(null);
            transform.SetParent(player.isWorkTop2.gameObject.transform);
            transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
            fish = true;
            this.gameObject.layer = 9;
            other.gameObject.tag = "SushiCook";
            
        }

        if (other.CompareTag("Prawn") && player.isWorkTop2.name == other.gameObject.transform.GetComponentsInParent<Transform>()[1].name && Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = putDownAudio;
            audioSource.Play();

            gameObject.transform.SetParent(null);
            transform.SetParent(player.isWorkTop2.gameObject.transform);
            transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
            transform.rotation = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].rotation;
            fish = true;
            this.gameObject.layer = 9;
            other.gameObject.tag = "PrawnCook";

        }

        if (other.CompareTag("CompleteDish") && gameObject.transform.root.tag == "Player")
        {
            isdishCheck = true;
            if (other.gameObject.transform.GetChild(0).name == player.isWorkTop2.name && Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(GetComponent<Rigidbody>());
                isfallCheck = true;
            }
        }
    }

}
