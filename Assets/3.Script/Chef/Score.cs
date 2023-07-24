using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Orderlist orderlist;
    public GameManager gameManager;
    public GameControll gameover;

    public Animator ani;

    public int score = 0;
    public int score2 = 0;// ���� ���� ���� ���� ������ ���ŵ� ������ �ִϸ��̼� ����ϱ� ���� ����
    public int tip = 0;
    public int tipCoin = 0;


    public Text text_score;


    void Start()
    {
        gameover = FindObjectOfType<GameControll>();
        gameManager = FindObjectOfType<GameManager>();
        orderlist = FindObjectOfType<Orderlist>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        text_score.text = score.ToString();
        if (tip >= 4)
        {
            tip = 4;
        }
        if (tip <= 0)
        {
            tip = 0;
        }
        if (score2 != score )
        {
            score2 = score;
            tipCoin = tip * 8;
            ani.SetTrigger("Coin");
            //Debug.Log("���� ���");
        }

        if (gameover.isEnd)
        {
            if (60 > score && score >= 20)
            {
                gameManager.level1_star = 1;
            }
            if (240 > score && score >= 60)
            {
                gameManager.level1_star = 2;
            }
            if (60 > score && score >= 20)
            {
                gameManager.level1_star = 3;
            }
        }
    }



}
