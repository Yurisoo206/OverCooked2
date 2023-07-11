using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTopCheck : MonoBehaviour
{
    public LayerMask layerMask;


    private void Update()
    {
        RaycastHit rayobject;
        if (Physics.Raycast(transform.position, transform.up, out rayobject, 6f, layerMask))
        {

        }
        Debug.DrawRay(transform.position, transform.up * 6f, Color.black);
    }


}
