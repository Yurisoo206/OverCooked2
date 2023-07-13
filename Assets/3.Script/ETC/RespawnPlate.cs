using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlate : MonoBehaviour
{
    public GameObject respawn;
    public GameObject plate;
    public GameObject plate_prefed;


    public bool respawnCheck = false;

    
    void Update()
    {

        if (respawnCheck)
        {
            Respawn();
            respawnCheck = false;
        }
        
    }


    private void Respawn()
    {       
        plate = Instantiate(plate_prefed, respawn.transform.position, respawn.transform.rotation);
        plate.transform.SetParent(gameObject.transform);
    }
}
