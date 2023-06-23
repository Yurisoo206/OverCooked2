using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worktop : MonoBehaviour
{

    public Material[] mat = new Material[2];
    public PlayerControll player;

    public MeshRenderer mesh;

    public GameObject isWorkTop;
    //public GameObject isWorkTop_2;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        player = FindObjectOfType<PlayerControll>();
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
            //Debug.Log("workTop �̸� : " + gameObject.name + "ray�̸� : " + player.isWorkTop.GetComponentsInChildren<Transform>()[2].name);
            //Debug.Log("��ġ �̸� : " + player.isWorkTop.GetComponentsInChildren<Transform>()[2].name);
            mesh.material = mat[1];
            player.ischeck = true;
        }
        else if(other.CompareTag("Player") && !player.ischeck && player.isWorkTop == null)//���� �ΰ��� ray �ν��� ���� ���⼭�� �ν� �� �Ҷ��� �������� ������Ʈ ����;
        {
            //isWorkTop = gameObject;//���̰� �ƴ� ��� ���� �浹���� ������Ʈ ����
            mesh.material = mat[1];
            player.ischeck = true;
        }
        //else if (other.CompareTag("Player") && player.ischeck && player.isWorkTop != null)
        //{
        //    Debug.Log("����");
        //    mesh.material = mat[0];
        //    player.ischeck = false;
        //}
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
