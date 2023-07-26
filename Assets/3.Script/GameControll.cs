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

    public AudioSource audioSource;
    public AudioSource bgmSource;

    public AudioClip startClip;
    public AudioClip gameoverAudio;
    public AudioClip bgmAudio;
    

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        audioSource = GetComponent<AudioSource>();
        bgmSource = GetComponent<AudioSource>();

        audioSource.Play();
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

        bgmSource.clip = bgmAudio;
        bgmSource.Play();
        
        isStart = true;
    }

    IEnumerator GameOver_Co()
    {
        bgmSource.clip = bgmAudio;
        bgmSource.Stop();
        audioSource.clip = gameoverAudio;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        
        resultUI.SetActive(true);
    }
}
