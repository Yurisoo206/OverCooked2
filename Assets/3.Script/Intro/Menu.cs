using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite; // 기본 스프라이트
    public Sprite hoverSprite; // 마우스가 올라갔을 때의 스프라이트

    private Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>(); // 버튼의 Image 컴포넌트 가져오기
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // 버튼 이미지 변경
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // 버튼 이미지 원래대로 복원
    }
}
