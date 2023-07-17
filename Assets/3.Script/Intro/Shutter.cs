using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    Vector3 target = new Vector3(0, 0.001f, 0);
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 0.5f);
    }
}


