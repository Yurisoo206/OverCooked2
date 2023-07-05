using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Sushi sushi;
    public PlayerControll player;

    private void Start()
    {
        sushi = FindObjectOfType<Sushi>();
        player = FindObjectOfType<PlayerControll>();
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !player.ishand)
        {
            transform.SetParent(other.gameObject.transform);
            transform.position = other.gameObject.GetComponentsInChildren<Transform>()[1].position;
            Debug.Log(other.gameObject.GetComponentsInChildren<Transform>()[1].name);
        }

        if (other.CompareTag("WorkTop") && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.SetParent(null);
            transform.position = other.gameObject.GetComponentsInParent<Transform>()[2].position;
        }
    }
}
