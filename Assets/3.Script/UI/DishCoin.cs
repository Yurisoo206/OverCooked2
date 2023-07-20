using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishCoin : MonoBehaviour
{
    public Score score;
    public Text text_score;

    private int coin = 0;

    private void Awake()
    {
        score = FindObjectOfType<Score>();

        
    }
    void Start()
    {
        coin = score.tipCoin;
        Debug.Log("거 팀 얼마나 받았나 함 봅시다" + coin);
        text_score.text = "+" + coin.ToString();
        Destroy(gameObject, 1f);

    }


}
