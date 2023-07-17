using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControll : MonoBehaviour
{
    public Transform[] dominoes; // ���̳� ������Ʈ���� �迭�� ����
    public Material upMaterial; // ���̳밡 �ö� �� ����� ���׸���
    //public Material downMaterial; // ���̳밡 ������ �� ����� ���׸���

    public float moveDuration = 0.1f; // ������Ʈ �̵��� �ɸ��� �ð�
    public float moveDelay = 0.1f; // ������Ʈ �̵� ���� ����
    public float moveHeight = 0.5f; // ���̳밡 �ö󰡴� ����

    private int currentDominoIndex = 0; // ���� ó�� ���� ���̳� �ε���
    private float timer = 0f; // Ÿ�̸�

    private Vector3[] originalPositions; // ���̳� ������Ʈ�� ���� ��ġ ����

    private void Start()
    {
        originalPositions = new Vector3[dominoes.Length];

        // �� ���̳� ������Ʈ�� ���� ��ġ ����
        for (int i = 0; i < dominoes.Length; i++)
        {
            originalPositions[i] = dominoes[i].position;
        }
    }

    private void Update()
    {
        // ���� ���̳� �ε����� �迭 ���� ���� ���� ������ �ݺ�
        if (currentDominoIndex < dominoes.Length)
        {
            // �̵� ���� �ð��� ����ϸ� ���� ���̳� �̵� ����
            if (timer >= moveDelay)
            {
                // ���� ���̳븦 ��ǥ ��ġ�� �̵���Ű�� ����
                float t = Mathf.Clamp01((timer - moveDelay) / moveDuration);

                // ���̳밡 ���� �ö󰡴� �ִϸ��̼�
                if (t < 0.5f)
                {
                    float heightT = Mathf.Lerp(0f, moveHeight, t * 10f);
                    dominoes[currentDominoIndex].position = originalPositions[currentDominoIndex] + new Vector3(0f, heightT, 0f);

                    // ���׸��� ����
                    Renderer renderer = dominoes[currentDominoIndex].GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = upMaterial;
                    }
                }
                // ���̳밡 ���� �ڸ��� �������� �ִϸ��̼�
                else
                {
                    float heightT = Mathf.Lerp(moveHeight, 0f, (t - 0.5f) * 10f);
                    dominoes[currentDominoIndex].position = originalPositions[currentDominoIndex] + new Vector3(0f, heightT, 0f);

                }

                // �̵��� �Ϸ�Ǹ� ���� ���̳� �ε����� �̵�
                if (t >= 0.1f)
                {
                    currentDominoIndex++;
                    timer = 0;
                }
            }

            timer += Time.deltaTime;
        }
    }
}
