using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingLevel1 : MonoBehaviour
{
    public Slider progressBar;
    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync("SushiMap");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (progressBar.value < 1f)
            {
                progressBar.value = Mathf.MoveTowards(progressBar.value, 1f, Time.deltaTime);
            }

            if (progressBar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
