using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Queue<GameObject> collisionQueue;
    private bool hasCollision = false;

    public GameObject plate;

    void Start()
    {
        collisionQueue = new Queue<GameObject>();
        plate = GetComponent<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plate") && !hasCollision)
        {
            plate = other.gameObject;
            hasCollision = true;
            Debug.Log(other.gameObject.name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plate") && !hasCollision )
        {
            if (plate != other.gameObject )
            {
                Debug.Log("�ߵǾ�� �ִ�...?" + other.gameObject.name);
                plate = other.gameObject;
                hasCollision = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plate") && hasCollision)
        {
            plate = null;

            // �浹�� ������Ʈ�� ���� ó��
            
            hasCollision = false;
        }
    }
}
