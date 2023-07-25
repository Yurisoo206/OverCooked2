using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeMap : MonoBehaviour
{
    public void ScenceChange()
    {
        SceneManager.LoadScene("Loading");
    }
}
