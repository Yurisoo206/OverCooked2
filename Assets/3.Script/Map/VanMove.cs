using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanMove : MonoBehaviour
{
    public float inputX { get; private set; }
    public float inputZ { get; private set; }
    public bool isInteraction_space { get; private set; }

    [HideInInspector] public MapProduce mapProduce;
    float speed = 5;
    void Start()
    {
        
        mapProduce = FindObjectOfType<MapProduce>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        isInteraction_space = Input.GetKeyDown(KeyCode.Space);
        if ((inputX != 0 || inputZ != 0))
        {
            Debug.Log("왜 안되는겨");
            Vector3 velocity = new Vector3(inputX, 0, inputZ).normalized;
            transform.position += velocity * speed * Time.deltaTime;
            transform.LookAt(transform.position + velocity);
        }
    }
}
