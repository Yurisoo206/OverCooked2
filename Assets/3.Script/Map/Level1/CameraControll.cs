using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera level1_Camera;
    public CinemachineVirtualCamera level2_Camera;

    bool isMove = false;

    private void Start()
    {
        if (GameManager.Instance.level1_Check)
        {
            playerCamera.enabled = false;
            level1_Camera.enabled = true;
        }
    }

    private void Update()
    {
        if (!isMove && !GameManager.Instance.level1_Check)
        {
            Invoke("level1_Move", 0.5f);
            isMove = false;
        }
        else if (GameManager.Instance.level1_Check)
        {
            Invoke("level2_Move", 1f);
            GameManager.Instance.level2_Check = true;
        }

    }

    private void level1_Move()
    {
        playerCamera.enabled = false;
        level1_Camera.enabled = true;
        Invoke("normalPos_1",2f);
    }

    private void level2_Move()
    {
        level1_Camera.enabled = false;
        level2_Camera.enabled = true;
        Invoke("normalPos_2", 3f);
    }


    private void normalPos_1()
    {
        playerCamera.enabled = true;
        level1_Camera.enabled = false;
    }
    private void normalPos_2()
    {
        playerCamera.enabled = true;
        level2_Camera.enabled = false;
    }

}
