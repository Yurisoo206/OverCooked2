using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoar : MonoBehaviour
{
    public PlayerControll player;

    GameObject knife = null;
    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        knife = transform.GetChild(3).gameObject;
    }
    private void Update()
    {
        Knife();
    }

    private void Knife()
    {
       
        if (!player.isCook)
        {
            knife.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (player.isCook))
        {
            knife.gameObject.SetActive(false);
        }
    }


}
