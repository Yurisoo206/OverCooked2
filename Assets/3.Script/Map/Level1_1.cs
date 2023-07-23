using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1_1 : MonoBehaviour
{
    private bool isMap = false;//±ê¹ß°ú ´ê¾Æ¼­ ¸ÊÀÌ ÄÑÁø °æ¿ì
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
        starImage1 = star1.transform.GetComponent<Image>();
        starImage2 = star2.transform.GetComponent<Image>();
        starImage3 = star3.transform.GetComponent<Image>();

        if (star >= 1)
        {
            starImage1.sprite = starSprite;
        }
        if (star >= 2)
        {
            starImage2.sprite = starSprite;
        }
        if (star >= 3)
        {
            starImage3.sprite = starSprite;
        }

    }

    private void Update()
    {
        if (isMap && Input.GetKeyDown(KeyCode.Space))
        {
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
