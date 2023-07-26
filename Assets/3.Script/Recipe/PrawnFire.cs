using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrawnFire : MonoBehaviour
{
    public PlayerControll player;

    public bool isplate = false;
    public bool isCooking = false;//workTop 올리는 거
    public bool isfall = false;//걍 바닥에 두는 용
    public bool isfallCheck = false;//

    public GameObject UI_Prefad;
    private GameObject UI;
    private GameObject workTopCheck;
    private GameObject plateTag;

    private int preChildcount;
    private bool check = false;

    public AudioSource audioSource;
    public AudioClip pickUpAudio;
    public AudioClip putDownAudio;

    private void Start()
    {
        UI = Instantiate(UI_Prefad, transform.position, Quaternion.identity, transform);
        UI.transform.rotation = transform.rotation.normalized;
        player = FindObjectOfType<PlayerControll>();
        workTopCheck = GetComponent<GameObject>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isfallCheck)
        {
            isfallCheck = false;
        }
        else if (gameObject.transform.root.tag == "Player" && Input.GetKeyDown(KeyCode.Space) && !player.isCollision && !isfall && !isfallCheck && !isCooking && !isplate)
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
        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space) && !isplate && !check)
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
                if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name && !isfall)
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
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && !isplate && !player.isCollision && isfall)
        {
            audioSource.clip = pickUpAudio;
            audioSource.Play();

            isfall = false;
            Destroy(GetComponent<Rigidbody>());
            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Plate") && !isplate && Input.GetKeyDown(KeyCode.Space) &&
            player.isWorkTop2.name == other.gameObject.transform.GetComponentsInParent<Transform>()[1].name)
        {
            audioSource.clip = putDownAudio;
            audioSource.Play();

            isplate = true;
            gameObject.transform.SetParent(null);
            transform.SetParent(other.gameObject.GetComponentsInChildren<Transform>()[1].transform);
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.gameObject.GetComponentsInChildren<Transform>()[1].transform.rotation;
            Debug.Log(gameObject.GetComponentsInParent<Transform>()[2].name);
            plateTag = gameObject.GetComponentsInParent<Transform>()[2].gameObject;
            plateTag.layer = 9;
            plateTag.tag = "SushiCook";
            Destroy(GetComponent<Rigidbody>());
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
                audioSource.clip = putDownAudio;
                audioSource.Play();
                check = true;
                gameObject.transform.SetParent(null);
                transform.SetParent(player.isWorkTop2.gameObject.transform);
                transform.position = player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].position;
                isCooking = true;
            }
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.isPlate && !isplate && !isfall && !player.ishand)
        {
            isfall = false;
            isfallCheck = true;

            audioSource.clip = pickUpAudio;
            audioSource.Play();

            if (gameObject.transform.parent != null)
            {
                if (player.isWorkTop2.name == gameObject.GetComponentsInParent<Transform>()[1].name)
                {
                    gameObject.transform.SetParent(null);
                }
            }

            check = false;

            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);

            Destroy(GetComponent<Rigidbody>());
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand && !isplate && !player.isCollision && isfall)
        {
            audioSource.clip = pickUpAudio;
            audioSource.Play();

            isfall = false;
            Destroy(GetComponent<Rigidbody>());
            check = false;
            transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.SetParent(other.gameObject.transform);
        }

        if (other.CompareTag("Plate") && !isplate && Input.GetKeyDown(KeyCode.Space) &&
            player.isWorkTop2.name == other.gameObject.transform.GetComponentsInParent<Transform>()[1].name)
        {
            audioSource.clip = pickUpAudio;
            audioSource.Play();

            isplate = true;
            gameObject.transform.SetParent(null);
            transform.SetParent(other.gameObject.GetComponentsInChildren<Transform>()[1].transform);
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[1].transform.position;
            transform.rotation = other.gameObject.GetComponentsInChildren<Transform>()[1].transform.rotation;
            Debug.Log(gameObject.GetComponentsInParent<Transform>()[2].name);
            plateTag = gameObject.GetComponentsInParent<Transform>()[2].gameObject;
            plateTag.layer = 9;
            plateTag.tag = "PrawnCook";
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
