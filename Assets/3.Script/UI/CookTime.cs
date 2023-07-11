using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookTime : MonoBehaviour
{
    public ChoppingBoar choppingBoar;
    public PlayerControll player;
    public Slider sliderTime;
    private float timeNum = 3f;
    GameObject cookCheck;

    private void Start()
    {
        sliderTime = GetComponent<Slider>();
        sliderTime.maxValue = timeNum;
        sliderTime.value = 0;
        cookCheck = gameObject.GetComponentsInParent<Transform>()[2].gameObject;
        player = FindObjectOfType<PlayerControll>();
    }
    void Update()
    {
        if (cookCheck == player.choppingBoar && player.isCook)
        {
            Cooktime();
        }
        if (sliderTime.value == timeNum)
        {
            player.isCook = false;

            sliderTime.value = 0;
            GameObject isOff = GetComponentsInParent<Transform>()[1].gameObject;
            isOff.SetActive(false);
            player.cookend = true;
        }
    }

    public void Cooktime()
    {
        if (sliderTime.value < timeNum)
        {
            sliderTime.value += Time.deltaTime;
        }
    }
}
