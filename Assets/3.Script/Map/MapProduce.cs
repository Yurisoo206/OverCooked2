using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProduce : MonoBehaviour
{
    private Animator ani;
    public bool ismove = false;

    void Start()
    {
        ani = GetComponent<Animator>();
        if (!GameManager.Instance.level1_Check)
        {
            Invoke("MapLevel_1", 1.5f);
        }
        else
        {
            ani.SetTrigger("Map1Check");
            ismove = true;
        }
    }

    void MapLevel_1()
    {
        ani.SetTrigger("Map1");
        Invoke("MoveTrue", 3f);
    }

    void MoveTrue()
    {
        ismove = true;
    }
    
}
