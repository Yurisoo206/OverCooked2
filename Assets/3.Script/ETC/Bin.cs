using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public PlayerControll player;

    private GameObject trash;

    void Start()
    {
        player = FindObjectOfType<PlayerControll>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (gameObject.name == player.isWorkTop2.GetComponentsInParent<Transform>()[2].name) && player.ishand)
        {
            player.ishand = false;
            Debug.Log("하 : " + other.gameObject.transform.GetChild(2).name);
            trash = other.transform.GetChild(2).gameObject;
            Debug.Log("잘 들어간겨? : " + trash.name);
            trash.transform.SetParent(null);
            //trash.transform.position = gameObject.transform.GetChild(0).position;       
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (gameObject.name == player.isWorkTop2.GetComponentsInParent<Transform>()[2].name) && player.ishand )
        {
            player.ishand = false;
            Debug.Log("하 : " + other.gameObject.transform.GetChild(2).name);
            trash = other.transform.GetChild(2).gameObject;
            Debug.Log("잘 들어간겨? : " + trash.name);
            trash.transform.SetParent(null);
            //trash.transform.position = gameObject.transform.GetChild(0).position;     
        }
    }
}
