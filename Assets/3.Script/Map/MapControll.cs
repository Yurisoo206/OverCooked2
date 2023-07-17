using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControll : MonoBehaviour
{
    public Transform[] dominoes; // 도미노 오브젝트들을 배열로 저장
    public Material upMaterial; // 도미노가 올라갈 때 사용할 메테리얼
    //public Material downMaterial; // 도미노가 내려올 때 사용할 메테리얼

    public float moveDuration = 0.1f; // 오브젝트 이동에 걸리는 시간
    public float moveDelay = 0.1f; // 오브젝트 이동 시작 간격
    public float moveHeight = 0.5f; // 도미노가 올라가는 높이

    private int currentDominoIndex = 0; // 현재 처리 중인 도미노 인덱스
    private float timer = 0f; // 타이머

    private Vector3[] originalPositions; // 도미노 오브젝트의 원래 위치 저장

    private void Start()
    {
        originalPositions = new Vector3[dominoes.Length];

        // 각 도미노 오브젝트의 원래 위치 저장
        for (int i = 0; i < dominoes.Length; i++)
        {
            originalPositions[i] = dominoes[i].position;
        }
    }

    private void Update()
    {
        // 현재 도미노 인덱스가 배열 범위 내에 있을 때까지 반복
        if (currentDominoIndex < dominoes.Length)
        {
            // 이동 지연 시간이 경과하면 다음 도미노 이동 시작
            if (timer >= moveDelay)
            {
                // 현재 도미노를 목표 위치로 이동시키는 보간
                float t = Mathf.Clamp01((timer - moveDelay) / moveDuration);

                // 도미노가 위로 올라가는 애니메이션
                if (t < 0.5f)
                {
                    float heightT = Mathf.Lerp(0f, moveHeight, t * 10f);
                    dominoes[currentDominoIndex].position = originalPositions[currentDominoIndex] + new Vector3(0f, heightT, 0f);

                    // 메테리얼 변경
                    Renderer renderer = dominoes[currentDominoIndex].GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = upMaterial;
                    }
                }
                // 도미노가 원래 자리로 내려오는 애니메이션
                else
                {
                    float heightT = Mathf.Lerp(moveHeight, 0f, (t - 0.5f) * 10f);
                    dominoes[currentDominoIndex].position = originalPositions[currentDominoIndex] + new Vector3(0f, heightT, 0f);

                }

                // 이동이 완료되면 다음 도미노 인덱스로 이동
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
