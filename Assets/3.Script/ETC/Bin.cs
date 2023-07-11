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
            Debug.Log("�Ͼ�,, ���� �� ���� ���� : " + player.isWorkTop2.GetComponentsInParent<Transform>()[2].name);
            Debug.Log("�� : " + gameObject.name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (gameObject.name == player.isWorkTop2.GetComponentsInParent<Transform>()[2].name))
        {
            Debug.Log("�Ͼ�,, ���� �� ���� ���� : " + player.isWorkTop2.GetComponentsInParent<Transform>()[2].name);
            Debug.Log("�� : " + gameObject.name);
        }
    }
}
