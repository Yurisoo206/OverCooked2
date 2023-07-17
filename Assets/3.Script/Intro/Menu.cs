using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalSprite; // �⺻ ��������Ʈ
    public Sprite hoverSprite; // ���콺�� �ö��� ���� ��������Ʈ

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
        buttonImage = GetComponent<Image>(); // ��ư�� Image ������Ʈ ��������
        buttonRectTransform = GetComponent<RectTransform>(); // ��ư�� RectTransform ������Ʈ ��������
        originalScale = buttonRectTransform.localScale; // ��ư�� �ʱ� ������ ����
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
        buttonImage.sprite = hoverSprite; // ��ư �̹��� ����
        isHovering = true;
        time = 0; // �ִϸ��̼� �ð� �ʱ�ȭ
        sheet.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log(sheet.transform.GetChild(0).gameObject);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite; // ��ư �̹��� ������� ����
        buttonRectTransform.localScale = originalScale; // ��ư ������ �ʱ�ȭ
        isHovering = false;
        sheet.transform.GetChild(0).gameObject.SetActive(false);
    }
}
