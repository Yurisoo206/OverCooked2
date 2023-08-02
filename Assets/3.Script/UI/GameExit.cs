using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    public GameObject exitUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitUI.SetActive(true);
        }
    }
}
