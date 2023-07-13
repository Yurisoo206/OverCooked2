using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Orderlist orderlist;

    public int score = 0;
    public Text text_score;

    void Start()
    {
        orderlist = FindObjectOfType<Orderlist>();
    }

    void Update()
    {
        text_score.text = score.ToString();
    }
}
