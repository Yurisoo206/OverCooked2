using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbox : MonoBehaviour
{
    PlayerInputManager playerInput;
    PlayerControll playerControll;

    public Transform playerPos;
    public GameObject fish_prefed;

    public GameObject fish;
    private Animator ani;

    private void Start()
    {
        playerInput = FindObjectOfType<PlayerInputManager>();
        playerControll = FindObjectOfType<PlayerControll>();
        ani = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInput.isInteraction_space)
        {
            playerControll.ishand = true;
            ani.SetTrigger("Open");
            playerPos = other.GetComponentsInChildren<Transform>()[1].transform;
            Debug.Log(playerPos);
            fish = Instantiate(fish_prefed, playerPos.position, playerPos.rotation);
            fish.transform.SetParent(other.gameObject.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerInput.isInteraction_space)
        {
            playerControll.ishand = true;
            ani.SetTrigger("Open");
            playerPos = other.GetComponentsInChildren<Transform>()[1].transform;
            Debug.Log(playerPos);
            fish = Instantiate(fish_prefed, playerPos.position, playerPos.rotation);
            fish.transform.SetParent(other.gameObject.transform);
        }
    }
}
