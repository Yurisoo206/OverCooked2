using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public PlayerControll player;
    public LayerMask layerMask1;
    public LayerMask layerMask2;
    private GameObject trash;

    private int preChildcount = 0;

    void Start() 
    {
        player = FindObjectOfType<PlayerControll>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && player.isWorkTop2.name == gameObject.transform.GetComponentsInChildren<Transform>()[4].name
            && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(player.isWorkTop2);
            Debug.Log(gameObject.transform.GetComponentsInChildren<Transform>()[4]);
            Transform parentTransform = player.transform;
            int childCount = parentTransform.childCount;

            RaycastHit rayobject;
            if (Physics.Raycast(transform.position, transform.up, out rayobject, 6f, layerMask1))
            {
                trash = rayobject.transform.gameObject;
                Debug.Log(trash);
            }
            //else if (Physics.Raycast(transform.position, transform.up, out rayobject, 6f, layerMask2))
            //{
            //    trash = rayobject.transform.gameObject;
            //    Debug.Log(rayobject);
            //}
            Debug.DrawRay(transform.position, transform.up * 6f, Color.black);


            Debug.Log(trash.tag);

            preChildcount = childCount;
            if (preChildcount >= 3)
            {






                //trash = other.gameObject.transform.GetChild(2).gameObject;

                //Debug.Log("하아 그만하고 싶다" + trash.tag);
                //trash.transform.SetParent(null);
                //trash.transform.SetParent(gameObject.transform.GetChild(0));
                //trash.transform.position = gameObject.transform.GetChild(0).position;
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.isWorkTop2.name == gameObject.transform.GetComponentsInChildren<Transform>()[4].name
            && Input.GetKeyDown(KeyCode.Space))
        {


            Debug.Log(player.isWorkTop2);
            Debug.Log(gameObject.transform.GetComponentsInChildren<Transform>()[4]);
            Transform parentTransform = player.transform;
            int childCount = parentTransform.childCount;

            RaycastHit rayobject;
            if (Physics.Raycast(transform.position, transform.up, out rayobject, 6f, layerMask1))
            {
                //trash = rayobject;
                Debug.Log(trash);
            }
            //else if (Physics.Raycast(transform.position, transform.up, out rayobject, 6f, layerMask2))
            //{
            //    trash = rayobject.transform.gameObject;
            //    Debug.Log(rayobject);
            //}
            Debug.DrawRay(transform.position, transform.up * 6f, Color.black);


            

            preChildcount = childCount;
            if (preChildcount >= 3)
            {






                //trash = other.gameObject.transform.GetChild(2).gameObject;

                //Debug.Log("하아 그만하고 싶다" + trash.tag);
                //trash.transform.SetParent(null);
                //trash.transform.SetParent(gameObject.transform.GetChild(0));
                //trash.transform.position = gameObject.transform.GetChild(0).position;
            }

        }
    }
}
