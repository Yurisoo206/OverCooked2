using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Orderlist orderlist;

    public Animator ani;

    public int score = 0;
    public int score2 = 0;
    public Text text_score;

    void Start()
    {
        orderlist = FindObjectOfType<Orderlist>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        text_score.text = score.ToString();

        if (score2 != score )
        {
            score2 = score;
            ani.SetTrigger("Coin");
            Debug.Log("Á¡¼ö »ó½Â");
        }
    }



}
