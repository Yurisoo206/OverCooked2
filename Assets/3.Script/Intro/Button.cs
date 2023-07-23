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

    public Sprite normalSprite; // �⺻ ��������Ʈ
    public Sprite hoverSprite; // ���콺�� �ö��� ���� ��������Ʈ
    public Animator ani;

    Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>(); // ��ư�� Image ������Ʈ ��������
        sheet = gameObject.transform.parent.gameObject;
        ani = GetComponent<Animator>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // ��ư �̹��� ����
        text.color = Color.white;
        //ani.SetTrigger("Button");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // ��ư �̹��� ������� ����
        text.color = new Color(0.3372549f, 0.5843138f, 0.6705883f, 1f);
        //sheet.transform.GetChild(0).gameObject.SetActive(false);
    }
}
