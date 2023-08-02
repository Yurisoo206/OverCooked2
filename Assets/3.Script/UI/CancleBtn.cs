using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CancleBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ExitUI;

    public Button button;

    public Sprite normalSprite; // �⺻ ��������Ʈ
    public Sprite hoverSprite; // ���콺�� �ö��� ���� ��������Ʈ

    Image buttonImage;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttonImage = GetComponent<Image>(); // ��ư�� Image ������Ʈ ��������
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // ��ư �̹��� ����
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // ��ư �̹��� ������� ����
    }

    public void CancleOption()
    {
        ExitUI.SetActive(false);
    }
}
