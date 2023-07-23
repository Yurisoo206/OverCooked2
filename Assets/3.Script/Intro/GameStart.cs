using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private Animator ani;
    private bool start = false;


    void Start()
    {
        ani = GetComponent<Animator>();
        start = false;
    }

    
    void Update()
    {
        if (!start && Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger("Start");
            start = true;
        }
    }


}
