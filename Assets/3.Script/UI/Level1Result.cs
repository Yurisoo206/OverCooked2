using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Result : MonoBehaviour
{
    public Score score;
    public GameManager gameManager;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private bool mapExit = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        score = FindObjectOfType<Score>();
    }

    void Start()
    {
        StartCoroutine(Star_co());


    }


    private void Update()
    {
        if (mapExit)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Map");
            }
        }
    }

    IEnumerator Star_co()
    {
        if (60 > score.score && score.score >= 20)
        {
            star1.SetActive(true);
            gameManager.level1_star = 1;
        }
        else if (240 > score.score && score.score >= 60)
        {
            star1.SetActive(true);

            yield return new WaitForSeconds(1f);

            star2.SetActive(true);
            gameManager.level1_star = 2;
        }
        else if (score.score >= 240)
        {
            star1.SetActive(true);

            yield return new WaitForSeconds(1f);

            star2.SetActive(true);

            yield return new WaitForSeconds(1f);

            star3.SetActive(true);
            gameManager.level1_star = 3;
        }

        yield return new WaitForSeconds(2f);
        mapExit = true;


        gameManager.level1_score = score.score; 
    }
}
