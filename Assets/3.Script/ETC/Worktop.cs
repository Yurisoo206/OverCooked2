using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worktop : MonoBehaviour
{

    public Material[] mat = new Material[2];
    public PlayerControll player;

    private MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        player = FindObjectOfType<PlayerControll>();
    }

    private void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.ischeck == false)
        {
            mesh.material = mat[1];
            player.ischeck = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            mesh.material = mat[0];
            player.ischeck = false;
            Debug.Log("나 분명 나갔다");
        }  
    }


    public void InWorkTop()
    {

    }
}
