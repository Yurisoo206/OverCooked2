using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1_1 : MonoBehaviour
{
    public GameManager gameManager;

    public Score score;
    private bool isMap = false;//깃발과 닿아서 맵이 켜진 경우
    private int ischeck = 0;//이거 게임 할 때마다 별 추가를 막기 위해
    
    public GameObject mapImage;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Sprite starSprite;

    Image starImage1;
    Image starImage2;
    Image starImage3;

    public Text text_score;
    public int star = 0;


    private void Start()
    {
        score = FindObjectOfType<Score>();
        gameManager = FindObjectOfType<GameManager>();
        starImage1 = star1.transform.GetComponent<Image>();
        starImage2 = star2.transform.GetComponent<Image>();
        starImage3 = star3.transform.GetComponent<Image>();

        text_score.text = gameManager.level1_score.ToString();

        if (star >= 3)
        {
            starImage1.sprite = starSprite;
            starImage2.sprite = starSprite;
            starImage3.sprite = starSprite;
            gameManager.level1_star += 3;
        }
        
        else if (star >= 2)
        {
            starImage1.sprite = starSprite;
            starImage2.sprite = starSprite;
            gameManager.level1_star += 2;
        }
        else if (star >= 1)
        {
            starImage1.sprite = starSprite;
            gameManager.level1_star++;
        }

    }

    private void Update()
    {
        if (isMap && Input.GetKeyDown(KeyCode.Space) )
        {
            //gameManager.savePos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameManager.gameCheck = true;
            gameManager.level1_Check = true;
            SceneManager.LoadScene("SushiMap");

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMap = true;
            mapImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMap = false;
            mapImage.SetActive(false);
        }
    }

}
