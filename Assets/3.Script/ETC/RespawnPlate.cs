using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlate : MonoBehaviour
{
    public PlayerControll player;

    public GameObject respawn;
    public GameObject plate;
    public GameObject plate_prefed;


    private GameObject workTop;
    private GameObject plateGet;

    public GameObject[] posList;

    List<GameObject> orderList = new List<GameObject>();
    public bool respawnCheck = false;


    int num = 0;

    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        workTop = gameObject.transform.GetComponentsInChildren<Transform>()[3].gameObject;
    }

    void Update()
    {
        if (respawnCheck && orderList.Count <=4)
        {
            StartCoroutine(Respawn_co());
        }
    }

    IEnumerator Respawn_co()
    {
        respawnCheck = false;
        yield return new WaitForSecondsRealtime(3f);

        plate = Instantiate(plate_prefed, respawn.transform.position, respawn.transform.rotation);
        plate.transform.SetParent(gameObject.transform);
        orderList.Add(plate);
        num++;

        if (num == orderList.Count)
        {
            orderList[num - 1].transform.position = posList[num - 1].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !player.ishand && workTop == player.isWorkTop2 && !player.ishand && Input.GetKeyDown(KeyCode.Space))
        {

            if (num >= 1)
            {
                plateGet = orderList[num - 1];
                orderList[num - 1].transform.SetParent(null);

                orderList.RemoveAt(num - 1);

                player.isPlate = true;
                plateGet.transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
                plateGet.transform.SetParent(other.gameObject.transform);
                num--;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !player.ishand && workTop == player.isWorkTop2 && !player.ishand && Input.GetKeyDown(KeyCode.Space))
        {

            if (num >= 1)
            {
                plateGet = orderList[num - 1];
                orderList[num - 1].transform.SetParent(null);

                orderList.RemoveAt(num - 1);

                player.isPlate = true;
                plateGet.transform.position = other.GetComponentsInChildren<Transform>()[1].transform.position;
                plateGet.transform.SetParent(other.gameObject.transform);
                num--;
            }

        }
    }

}
