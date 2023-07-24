using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    private Animator ani;
    private bool start = false;
    public AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        start = false;
    }


    void Update()
    {
        if (!start && Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            ani.SetTrigger("Start");
            start = true;
        }
    }
}


