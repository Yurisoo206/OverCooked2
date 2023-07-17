using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite; // 기본 스프라이트
    public Sprite hoverSprite; // 마우스가 올라갔을 때의 스프라이트

    Image buttonImage;
    RectTransform buttonRectTransform;

    bool isHovering = false;
    Vector3 originalScale;

    float time = 0;
    public float maxScale = 1.2f;
    public float animationTime = 0.2f;

    public GameObject sheet;
    private void Awake()
    {
        buttonImage = GetComponent<Image>(); // 버튼의 Image 컴포넌트 가져오기
        buttonRectTransform = GetComponent<RectTransform>(); // 버튼의 RectTransform 컴포넌트 가져오기
        originalScale = buttonRectTransform.localScale; // 버튼의 초기 스케일 저장
        sheet = gameObject.transform.parent.gameObject;
    }

    private void Update()
    {
        if (isHovering)
        {
            if (time <= animationTime / 2)
            {
                float t = time / (animationTime / 2);
                float scale = Mathf.Lerp(1f, maxScale, t);
                buttonRectTransform.localScale = originalScale * scale;
            }
            else if (time <= animationTime)
            {
                float t = (time - (animationTime / 2)) / (animationTime / 2);
                float scale = Mathf.Lerp(maxScale, 1f, t);
                buttonRectTransform.localScale = originalScale * scale;
            }

            time += Time.deltaTime;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // 버튼 이미지 변경
        isHovering = true;
        time = 0; // 애니메이션 시간 초기화
        sheet.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log(sheet.transform.GetChild(0).gameObject);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // 버튼 이미지 원래대로 복원
        buttonRectTransform.localScale = originalScale; // 버튼 스케일 초기화
        isHovering = false;
        sheet.transform.GetChild(0).gameObject.SetActive(false);
    }
}
