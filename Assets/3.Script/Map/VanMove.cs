using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanMove : MonoBehaviour
{
    [HideInInspector] public MapProduce mapProduce;
    public GameManager gameManager;

    public float inputX { get; private set; }
    public float inputZ { get; private set; }

    float speed = 5;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        mapProduce = FindObjectOfType<MapProduce>();
        if (gameManager.gameCheck)
        {
            transform.position 
            = new Vector3(gameManager.savePos.position.x, gameManager.savePos.position.y, gameManager.savePos.position.z);
        }
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        if ((inputX != 0 || inputZ != 0) && mapProduce.ismove)
        {
            Vector3 velocity = new Vector3(inputX, 0, inputZ).normalized;
            transform.position += velocity * speed * Time.deltaTime;
            transform.LookAt(transform.position + velocity);
        }
    }
}
