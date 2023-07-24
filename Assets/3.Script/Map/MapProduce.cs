using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProduce : MonoBehaviour
{
    public GameManager gameManager;
    private Animator ani;
    public bool ismove = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        ani = GetComponent<Animator>();
        if (!gameManager.level1_Check)
        {
            Invoke("MapLevel_1", 1.5f);
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
