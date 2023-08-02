using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalStar : MonoBehaviour
{
    public int totalStar = 0;
    public Text totalText;

    void Update()
    {
        totalText.text = GameManager.Instance.totalStar.ToString();
    }
}
