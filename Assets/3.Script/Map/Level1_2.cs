using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_2 : MonoBehaviour
{
    public GameObject mapImage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mapImage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mapImage.SetActive(false);
        }
    }
}
