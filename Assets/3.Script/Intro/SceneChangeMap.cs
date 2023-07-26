using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeMap : MonoBehaviour
{
    public GameObject volume;
    public void ScenceChange()
    {
        SceneManager.LoadScene("Loading");
    }

    public void OptionVolume()
    {
        volume.SetActive(true);
    }

    public void OptionVolumeExit()
    {
        volume.SetActive(false);
    }
}
