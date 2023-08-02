using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Orderlist orderlist;
    public GameControll gameover;

    public Animator ani;

    public int score = 0;
    public int score2 = 0;// 점수 이전 값을 저장 점수가 갱신될 때마나 애니메이션 재생하기 위해 설정
    public int tip = 0;
    public int tipCoin = 0;

    public GameObject tip2;
    public GameObject tip3;


    public Text text_score;
    public Text text_tip;

    void Start()
    {
        gameover = FindObjectOfType<GameControll>();
        orderlist = FindObjectOfType<Orderlist>();
        ani = GetComponent<Animator>();
        
    }

    void Update()
    {
        text_score.text = score.ToString();
        text_tip.text = "X" + tip.ToString();

        if (tip > 0)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            if (tip == 2)
            {
                tip2.SetActive(true);
            }
            if (tip == 3)
            {
                tip3.SetActive(true);
            }
        }
        if (tip >= 4)
        {
            
            tip = 4;
        }
        if (tip <= 0)
        {
            tip2.SetActive(false);
            tip3.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            tip = 0;
        }
        if (score2 != score )
        {
            score2 = score;
            tipCoin = tip * 8;
            ani.SetTrigger("Coin");
        }

        if (gameover.isEnd)
        {
            if (60 > score && score >= 20)
            {
                GameManager.Instance.level1_star = 1;
            }
            else if (240 > score && score >= 60)
            {
                GameManager.Instance.level1_star = 2;
            }
            else if (240 >= score)
            {
                GameManager.Instance.level1_star = 3;
            }
        }
    }



}
