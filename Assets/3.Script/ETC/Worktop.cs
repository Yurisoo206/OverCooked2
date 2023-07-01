using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worktop : MonoBehaviour
{
    public Material[] mat = new Material[2];
    public PlayerControll player;

    public MeshRenderer mesh;
    

    [SerializeField] bool isCheck = false;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        player = FindObjectOfType<PlayerControll>();
    }


    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            Debug.Log("이거 체크했다" + isCheck);
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
        }
        else if(other.CompareTag("Player") && !player.ischeck && player.isWorkTop == null)//위에 두개는 ray 인식이 기준 여기서는 인식 안 할때를 기준으로 오브젝트 생성;
        {
            mesh.material = mat[1];
            player.ischeck = true;
            player.isWorkTop2 = gameObject;
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
