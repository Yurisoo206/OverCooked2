using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite; // �⺻ ��������Ʈ
    public Sprite hoverSprite; // ���콺�� �ö��� ���� ��������Ʈ

    private Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>(); // ��ư�� Image ������Ʈ ��������
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // ��ư �̹��� ����
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // ��ư �̹��� ������� ����
    }
}
