using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbox : MonoBehaviour
{
    PlayerInputManager playerInput;
    PlayerControll player;

    public Transform playerPos;
    public GameObject fish_prefed;

    public GameObject fish;
    private Animator ani;

    private void Start()
    {
        playerInput = FindObjectOfType<PlayerInputManager>();
        player = FindObjectOfType<PlayerControll>();
        ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInput.isInteraction_space && !player.ishand &&
            player.isWorkTop2.name == gameObject.transform.GetComponentsInChildren<Transform>()[7].name)
        {
            Debug.Log(player.isWorkTop2.name);
            Debug.Log(gameObject.transform.GetComponentsInChildren<Transform>()[7]);
            player.ishand = true;
            ani.SetTrigger("Open");
            playerPos = other.GetComponentsInChildren<Transform>()[1].transform;
            fish = Instantiate(fish_prefed, playerPos.position, playerPos.rotation);
            fish.transform.SetParent(other.gameObject.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerInput.isInteraction_space && !player.ishand &&
            player.isWorkTop2.name == gameObject.transform.GetComponentsInChildren<Transform>()[7].name)
        {
            Debug.Log(player.isWorkTop2.name);
            Debug.Log(gameObject.transform.GetComponentsInChildren<Transform>()[7]);
            player.ishand = true;
            ani.SetTrigger("Open");
            playerPos = other.GetComponentsInChildren<Transform>()[1].transform;
            fish = Instantiate(fish_prefed, playerPos.position, playerPos.rotation);
            fish.transform.SetParent(other.gameObject.transform);
        }
    }
}
