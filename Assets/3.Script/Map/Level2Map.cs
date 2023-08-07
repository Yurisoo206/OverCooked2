using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Map : MonoBehaviour
{
    private Animator ani;
    public GameObject level2Flag;
    public GameObject level2FPath;

    void Start()
    {
        ani = GetComponent<Animator>();
        if (GameManager.Instance.level1_star != 0)
        {
            GameManager.Instance.level2_Check = true;
            Invoke("MapLevel_2", 1.5f);
            level2Flag.SetActive(true);
            Invoke("MapPath", 1f);
        }

    }

    void MapLevel_2()
    {
        ani.SetTrigger("Map");
    }

    void MapPath()
    {
        level2FPath.SetActive(true);
    }

}
