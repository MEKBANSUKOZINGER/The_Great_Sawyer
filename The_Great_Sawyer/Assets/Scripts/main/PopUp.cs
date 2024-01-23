using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hider;
    public RectTransform arrPoint;
    public RectTransform hiddenPoint;
    public RectTransform popUp;
    private bool isPoped;

    void Start()
    {
        hider.SetActive(false);
        isPoped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void popFunc()
    {
        if (!isPoped)
        {
            hider.SetActive(true);
            popUp.DOMoveY(arrPoint.position.y, 0.3f).SetEase(Ease.InOutSine);
        } else
        {
            hider.SetActive(false);
            popUp.DOMoveY(hiddenPoint.position.y, 0.3f).SetEase(Ease.InOutSine);
        }
        isPoped = !isPoped;
    }
}
