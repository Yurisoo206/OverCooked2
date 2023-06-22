using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishbox : MonoBehaviour
{
    PlayerInputManager playerInput;

    public Transform playerPos;
    public GameObject fish_prefed;
    public GameObject setParent_player;

    public GameObject fish;

    private void Start()
    {
        playerInput = FindObjectOfType<PlayerInputManager>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerInput.isInteraction_space)
        {
            fish = Instantiate(fish_prefed, playerPos.position, playerPos.rotation);
            fish.transform.SetParent(other.gameObject.transform);
        }
    }
}
