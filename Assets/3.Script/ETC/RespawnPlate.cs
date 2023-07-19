using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlate : MonoBehaviour
{
    public GameObject respawn;
    public GameObject plate;
    public GameObject plate_prefed;

    public GameObject[] posList;
    GameObject[] setList;

    List<GameObject> orderList = new List<GameObject>();
    public bool respawnCheck = false;


    int num = 0;
    private void Start()
    {
        setList = new GameObject[5];
    }

    void Update()
    {
        if (respawnCheck && orderList.Count <=4)
        {

            Respawn();
            
        }
        
    }

    private void Respawn()
    {
        respawnCheck = false;
        plate = Instantiate(plate_prefed, respawn.transform.position, respawn.transform.rotation);
        plate.transform.SetParent(gameObject.transform);
        orderList.Add(plate);
        Debug.Log("접시 orderList.Count" + orderList.Count);
        num++;

        Debug.Log("접시 num" + num);

        if (num == orderList.Count)
        {
            orderList[num - 1].transform.position = posList[num - 1].transform.position;

            Debug.Log("orderlist" + orderList[num - 1].transform.position);
            Debug.Log("posList" + posList[num - 1].transform.position + "위치" + posList[num - 1]);
            
        }

        
    }
}
