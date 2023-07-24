using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public Timer timer;

    public GameObject readyUI;
    public GameObject startUI;
    public GameObject overUI;
    public GameObject resultUI;

    private bool gameStart = false;
    public bool isStart = false;
    public bool isEnd = false;

    public bool gameOver= false;



    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        if (!gameStart)
        {
            gameStart = true;
            StartCoroutine(GameStart_Co());
        }
        if (timer.LimitTime <= 0)
        {
            isEnd = true;
            isStart = false;
            overUI.SetActive(true);
            if (!gameOver)
            {
                gameOver = true;
                StartCoroutine(GameOver_Co());
            }
        }
    }

    IEnumerator GameStart_Co()
    {
        readyUI.SetActive(true);
        yield return new WaitForSeconds(1f);

        startUI.SetActive(true);

        readyUI.SetActive(false);
        yield return new WaitForSeconds(1f);

        startUI.SetActive(false);
        yield return new WaitForSeconds(1f);
        isStart = true;
    }

    IEnumerator GameOver_Co()
    {
        yield return new WaitForSeconds(2f);

        resultUI.SetActive(true);
    }
}
