using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public PlayerControll player;

    private GameObject workTop;

    void Start()
    {
        player = FindObjectOfType<PlayerControll>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (gameObject.name == player.isWorkTop2.GetComponentsInParent<Transform>()[2].name))
        {
            Debug.Log("하아,, 이제 좀 쉽게 가자 : " + player.isWorkTop2.GetComponentsInParent<Transform>()[2].name);
            Debug.Log("하 : " + gameObject.name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (gameObject.name == player.isWorkTop2.GetComponentsInParent<Transform>()[2].name))
        {
            Debug.Log("하아,, 이제 좀 쉽게 가자 : " + player.isWorkTop2.GetComponentsInParent<Transform>()[2].name);
            Debug.Log("하 : " + gameObject.name);
        }
    }
}
