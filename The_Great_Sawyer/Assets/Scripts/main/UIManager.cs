using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainGeneral : MonoBehaviour
{
    private string date;

    private bool isToggled;

    private bool isHiden;

    public TextMeshProUGUI dateText;

    public Image toggle;
    public Image toggleElem;

    public GameObject topUI;
    public GameObject leftUI;
    public GameObject rightUI;
    public GameObject bottomUI;

    // Start is called before the first frame update
    void Start()
    {
        isToggled = false;
        isHiden = false;
    }

    // Update is called once per frame
    void Update()
    {
        date = DateTime.Now.ToString(("HHmm"));
        //0�� ~ 6�� = ����
        //6�� ~ 10�� = ��ħ
        //10�� ~ 15�� = ��
        // 15�� ~ 19�� = ����
        // 19�� ~ 24�� = ��
        if (Int32.Parse(date) >= 0 && Int32.Parse(date) < 600)
        {
            dateText.text = "���� " + date[0] + date[1] + "�� " + date[2] + date[3] + "��";
        } else if (Int32.Parse(date) >= 600 && Int32.Parse(date) < 1000)
        {
            dateText.text = "��ħ " + date[0] + date[1] + "�� " + date[2] + date[3] + "��";
        }
        else if (Int32.Parse(date) >= 1000 && Int32.Parse(date) < 1500)
        {
            dateText.text = "�� " + date[0] + date[1] + "�� " + date[2] + date[3] + "��";
        }
        else if (Int32.Parse(date) >= 1500 && Int32.Parse(date) < 1900)
        {
            dateText.text = "���� " + date[0] + date[1] + "�� " + date[2] + date[3] + "��";
        }
        else if (Int32.Parse(date) >= 1900 && Int32.Parse(date) < 2400)
        {
            dateText.text = "�� " + date[0] + date[1] + "�� " + date[2] + date[3] + "��";
        }
    }

    public void Toggle()
    {
        if (!isToggled)
        {
            toggle.rectTransform.DOMoveX(1400f, 0.25f).SetEase(Ease.OutSine);
            toggleElem.rectTransform.DORotate(new Vector3(0, 0, 180f), 0.25f).SetEase(Ease.OutSine);
            isToggled = !isToggled;
        } else
        {
            toggle.rectTransform.DOMoveX(1880f, 0.25f).SetEase(Ease.OutSine);
            toggleElem.rectTransform.DORotate(new Vector3(0, 0, 0f), 0.25f).SetEase(Ease.OutSine);
            isToggled = !isToggled;
        }
    }

    public void hideUI()
    {
        if (!isHiden) { 
            topUI.transform.DOMoveY(Screen.height, 0.5f).SetEase(Ease.InOutSine);
            leftUI.transform.DOMoveX(- Screen.width/2, 0.5f).SetEase(Ease.InOutSine);
            rightUI.transform.DOMoveX(Screen.width * 2, 0.5f).SetEase(Ease.InOutSine);
            bottomUI.transform.DOMoveY(-Screen.height / 2, 0.5f).SetEase(Ease.InOutSine);
            isHiden = !isHiden;
        } else
        {
            topUI.transform.DOMoveY(Screen.height / 2, 0.5f).SetEase(Ease.InOutSine);
            leftUI.transform.DOMoveX(40f, 0.5f).SetEase(Ease.InOutSine);
            rightUI.transform.DOMoveX(Screen.width, 0.5f).SetEase(Ease.InOutSine);
            bottomUI.transform.DOMoveY(Screen.height / 2, 0.5f).SetEase(Ease.InOutSine);
            isHiden = !isHiden;
        }
    }

    public void walk()
    {
        SceneManager.LoadScene("walk");
    }
}
