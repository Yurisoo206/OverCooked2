using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject btn;
    public GameObject sheet;

    public Sprite normalSprite; // �⺻ ��������Ʈ
    public Sprite hoverSprite; // ���콺�� �ö��� ���� ��������Ʈ
    public Animator ani;

    Image buttonImage;

    public AudioSource audioSource;
    public AudioClip audioClip;
    

    private void Start()
    {
        buttonImage = btn.transform.GetComponent<Image>(); // ��ư�� Image ������Ʈ ��������
        ani = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioClip = GetComponent<AudioClip>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; // ��ư �̹��� ����
        ani.SetTrigger("Button");
        transform.GetChild(0).gameObject.SetActive(true);
        audioSource.Play();
 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // ��ư �̹��� ������� ����
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
