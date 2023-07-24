using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public GameControll gameControll;
    public float inputX { get; private set; }
    public float inputZ { get; private set; }
    public bool isInteraction_space { get; private set; }

    private void Start()
    {
        gameControll = FindObjectOfType<GameControll>();
    }

    private void Update()
    {
        if (!gameControll.isEnd || gameControll.isStart)
        {
            inputX = Input.GetAxis("Horizontal");
            inputZ = Input.GetAxis("Vertical");

            isInteraction_space = Input.GetKeyDown(KeyCode.Space);
        }
        
    }
 
}
