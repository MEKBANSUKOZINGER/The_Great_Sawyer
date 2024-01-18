using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainStart : MonoBehaviour
{

    public Image semiWhite;
    public Image semiWhite_2;
    public Image white;
    public Image realWhite;

    // Start is called before the first frame update
    void Start()
    {
        SplashManager.instance.SetResolution();
        white.rectTransform.DOMoveX(-1080f, 1f).SetEase(Ease.OutSine);
        realWhite.rectTransform.DOMoveX(-1620f, 1f).SetEase(Ease.OutSine);
        semiWhite.rectTransform.DOMoveX(-1080f, 0.75f).SetEase(Ease.OutSine).SetDelay(0.5f);
        semiWhite_2.rectTransform.DOMoveX(-1080f, 1f).SetEase(Ease.OutSine).SetDelay(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
