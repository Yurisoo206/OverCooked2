using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishCoinUI : MonoBehaviour
{
    public Transform dishCoinPos;
    public GameObject dishCoin_prefed;

    private GameObject dishCoin;

    public bool dishcoinActive = false;

    private void Update()
    {
        if (dishcoinActive)
        {
            //Debug.Log("фа");
            dishCoin = Instantiate(dishCoin_prefed, dishCoinPos.position, dishCoinPos.rotation);
            dishCoin.transform.SetParent(gameObject.transform);
            dishcoinActive = false;
        }
        
    }
}
