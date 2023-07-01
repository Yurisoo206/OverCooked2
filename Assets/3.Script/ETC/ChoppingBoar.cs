using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoar : MonoBehaviour
{
    public PlayerControll player;

    GameObject knife = null;
    GameObject workTop = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        knife = transform.GetChild(3).gameObject;
        workTop = transform.GetChild(0).gameObject;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && 
            (player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].name == workTop.name) &&
            Input.GetKeyDown(KeyCode.E) )
        {
            player.isCook = true;
            Debug.Log(" 이름이 뭐예여" + player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].name);
            Debug.Log(" 내이름은" + workTop.name);
            knife.gameObject.SetActive(false);
        }
        if (other.CompareTag("Player") &&
            (player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].name != workTop.name))
        {
            player.isCook = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") &&
            (player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].name == workTop.name) &&
            Input.GetKeyDown(KeyCode.E))
        {
            player.isCook = true;
            Debug.Log(" 이름이 뭐예여"  + player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].name);
            Debug.Log(" 내이름은"  + workTop.name);
            knife.gameObject.SetActive(false);
        }

        if (other.CompareTag("Player") &&
            (player.isWorkTop2.gameObject.GetComponentsInParent<Transform>()[2].name != workTop.name))
        {
            player.isCook = false;
        }
    }


}
