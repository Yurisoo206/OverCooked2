using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worktop : MonoBehaviour
{
    public Material[] mat = new Material[2];
    public PlayerControll player;

    public MeshRenderer mesh;

    private int preChildcount;
    private bool check = false;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        player = FindObjectOfType<PlayerControll>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.ischeck && player.isWorkTop != null && gameObject.name != player.isWorkTop.GetComponentsInChildren<Transform>()[2].name)
        {
            mesh.material = mat[0];
            player.ischeck = false;
        }

        if (other.CompareTag("Player") && !player.ischeck && player.isWorkTop != null && gameObject.name == player.isWorkTop.GetComponentsInChildren<Transform>()[2].name)
        {
            mesh.material = mat[1];
            player.ischeck = true;
            player.isWorkTop2 = gameObject;

            //Transform parentTransform = gameObject.transform;
            //int childCount = parentTransform.childCount;
            
            //preChildcount = childCount;
            //if (preChildcount < 3)
            //{
            //    check = true;
                
            
            //}

        }
        else if (other.CompareTag("Player") && !player.ischeck && player.isWorkTop == null)//是拭 砧鯵澗 ray 昔縦戚 奄層 食奄辞澗 昔縦 照 拝凶研 奄層生稽 神崎詮闘 持失;
        {
            mesh.material = mat[1];
            player.ischeck = true;
            player.isWorkTop2 = gameObject;
            //Transform parentTransform = workTopCheck.transform;
            //int childCount = parentTransform.childCount;

            //preChildcount = childCount;
            //if (preChildcount < 3)
            //{
            //    check = true;
            //    Debug.Log(" 醤松 失因 唖戚陥たたた");

            //}
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.ischeck && player.isWorkTop != null && gameObject.name != player.isWorkTop.GetComponentsInChildren<Transform>()[2].name)
        {
            mesh.material = mat[0];
            player.ischeck = false;
        }
        
        if (other.CompareTag("Player") && !player.ischeck  && player.isWorkTop != null && gameObject.name == player.isWorkTop.GetComponentsInChildren<Transform>()[2].name)
        {
            mesh.material = mat[1];
            player.ischeck = true;
            player.isWorkTop2 = gameObject;
            //Transform parentTransform = workTopCheck.transform;
            //int childCount = parentTransform.childCount;

            //preChildcount = childCount;
            //if (preChildcount < 3)
            //{
            //    check = true;
            //    Debug.Log(" 醤松 失因 唖戚陥たたた");

            //}

        }
        else if(other.CompareTag("Player") && !player.ischeck && player.isWorkTop == null)//是拭 砧鯵澗 ray 昔縦戚 奄層 食奄辞澗 昔縦 照 拝凶研 奄層生稽 神崎詮闘 持失;
        {
            mesh.material = mat[1];
            player.ischeck = true;
            player.isWorkTop2 = gameObject;
            //Transform parentTransform = workTopCheck.transform;
            //int childCount = parentTransform.childCount;

            //preChildcount = childCount;
            //if (preChildcount < 3)
            //{
            //    check = true;
            //    Debug.Log(" 醤松 失因 唖戚陥たたた");

            //}
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && player.isWorkTop == null)
        {
            mesh.material = mat[0];
            player.ischeck = false;
        }  
    }
}     
