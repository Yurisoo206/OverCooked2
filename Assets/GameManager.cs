using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalStar = 0;
    public int level1_star = 0;
    public int level1_score = 0;

    public bool gameCheck = false;
    public bool level1_Check = false;


    public Transform savePos ;

    void Start()
    {
        
        totalStar = level1_star;
    }

    void Update()
    {
        
    }
}
