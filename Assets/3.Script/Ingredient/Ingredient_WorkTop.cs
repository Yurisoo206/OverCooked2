using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient_WorkTop : MonoBehaviour
{
    public Material[] mat = new Material[2];
    public PlayerControll player;

    public MeshRenderer mesh;

    public GameObject isWorkTop;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        player = FindObjectOfType<PlayerControll>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !player.ischeck)
        {
            mesh.material = mat[1];
            player.ischeck = true;
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
