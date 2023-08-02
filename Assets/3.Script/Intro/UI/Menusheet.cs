using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menusheet : MonoBehaviour
{
    float time;


    private void Start()
    {
        
    }

    void Update()
    {
        if (time < 0.4f)
        {
            this.transform.position = new Vector3(0, 12 - 30 * time, 0);
        }
        else if (time < 0.5f)
        {
            float t = (time - 0.4f) * 4;
            this.transform.position = new Vector3(0, 0.4f * 4 - t, 0);
        }
        else if (time < 0.6f)
        {
            float t = (time - 0.5f) * 4;
            this.transform.position = new Vector3(0, t, 0);
        }
        else
        {
            this.transform.position = Vector3.zero;
        }

        time += Time.deltaTime;
    }
}
