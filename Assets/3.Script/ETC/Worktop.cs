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
        else if (other.CompareTag("Player") && !player.ischeck && player.isWorkTop == null)//위에 두개는 ray 인식이 기준 여기서는 인식 안 할때를 기준으로 오브젝트 생성;
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
            //    Debug.Log(" 야씨 성공 각이다ㅏㅏㅏ");

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
            //    Debug.Log(" 야씨 성공 각이다ㅏㅏㅏ");

            //}

        }
        else if(other.CompareTag("Player") && !player.ischeck && player.isWorkTop == null)//위에 두개는 ray 인식이 기준 여기서는 인식 안 할때를 기준으로 오브젝트 생성;
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
            //    Debug.Log(" 야씨 성공 각이다ㅏㅏㅏ");

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
