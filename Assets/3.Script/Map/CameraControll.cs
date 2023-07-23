using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform player;
    Vector3 rotation = new Vector3(30f, -2.618f, -0.006f);




    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 10f, player.position.z - 5f);
        //transform.rotation = Quaternion.Euler(rotation);
    }
}
