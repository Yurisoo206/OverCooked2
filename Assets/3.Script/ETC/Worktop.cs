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
        }
        else if (other.CompareTag("Player") && !player.ischeck && player.isWorkTop == null)//���� �ΰ��� ray �ν��� ���� ���⼭�� �ν� �� �Ҷ��� �������� ������Ʈ ����;
        {
            mesh.material = mat[1];
            player.ischeck = true;
            player.isWorkTop2 = gameObject;
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
        else if(other.CompareTag("Player") && !player.ischeck && player.isWorkTop == null)//���� �ΰ��� ray �ν��� ���� ���⼭�� �ν� �� �Ҷ��� �������� ������Ʈ ����;
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
