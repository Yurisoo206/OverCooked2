using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public Transform obj;
    void Update()
    {
        transform.position = obj.position;
    }
}
                                                                                                                                        