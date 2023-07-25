using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera level1_Camera;

    bool isMove = false;


    private void Update()
    {
        if (!isMove && !GameManager.Instance.level1_Check)
        {
            Invoke("level1_Move", 0.5f);
            isMove = false;
        }
    }

    private void level1_Move()
    {
        playerCamera.enabled = false;
        level1_Camera.enabled = true;
        Invoke("normalPos",2f);
    }

    private void normalPos()
    {
        playerCamera.enabled = true;
        level1_Camera.enabled = false;
    }
}
