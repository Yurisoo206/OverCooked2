using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProduce : MonoBehaviour
{
    private Animator ani;
    public bool moveTrue = true;

    void Start()
    {
        moveTrue = true;
        ani = GetComponent<Animator>();
        Invoke("MapLevel_1", 1f);
    }

    void MapLevel_1()
    {
        
        ani.SetTrigger("Map1");
        Invoke("MoveTrue", 3f);
        Debug.Log("작동확인");
    }

    void MoveTrue()
    {
        moveTrue = false;
    }
    
}
