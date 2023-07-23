using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public Text text;
    public GameObject menu;
    public GameObject sheet;

    public Sprite normalSprite; // 기본 스프라이트
    public Sprite hoverSprite; // 마우스가 올라갔을 때의 스프라이트
    public Animator ani;

    Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>(); // 버튼의 Image 컴포넌트 가져오기
        sheet = gameObject.transform.parent.gameObject;
        ani = GetComponent<Animator>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // 버튼 이미지 변경
        text.color = Color.white;
        //ani.SetTrigger("Button");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // 버튼 이미지 원래대로 복원
        text.color = new Color(0.3372549f, 0.5843138f, 0.6705883f, 1f);
        //sheet.transform.GetChild(0).gameObject.SetActive(false);
    }
}
