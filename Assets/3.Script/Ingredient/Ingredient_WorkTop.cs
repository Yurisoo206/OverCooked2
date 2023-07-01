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
        if (other.CompareTag("Player") && !player.ischeck)//위에 두개는 ray 인식이 기준 여기서는 인식 안 할때를 기준으로 오브젝트 생성;
        {
            //isWorkTop = gameObject;//레이가 아닐 경우 현재 충돌중인 오브젝트 저장
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
