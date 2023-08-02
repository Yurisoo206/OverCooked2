using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;

    public Sprite normalSprite; // 기본 스프라이트
    public Sprite hoverSprite; // 마우스가 올라갔을 때의 스프라이트

    Image buttonImage;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttonImage = GetComponent<Image>(); // 버튼의 Image 컴포넌트 가져오기
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // 버튼 이미지 변경
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // 버튼 이미지 원래대로 복원
    }

    public void ExitGame()
    {
        Debug.Log("종료");
        Application.Quit();
    }
}
