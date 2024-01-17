using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTime : MonoBehaviour
{
    public Image sky;
    public List<Image> Lights = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dayTime()
    {
        sky.DOFade(0, 1f).SetEase(Ease.InOutSine);
        for (int i = 0; i < Lights.Count; i++)
        {
            Lights[i].DOFade(1, 0.5f).SetEase(Ease.InOutSine).SetDelay(0.25f);
        }
    }

    public void midnight()
    {
        sky.DOFade(1, 1f).SetEase(Ease.InOutSine);
        for (int i = 0; i < Lights.Count; i++)
        {
            Lights[i].DOFade(0, 0.5f).SetEase(Ease.InOutSine).SetDelay(0.1f);
        }
    }
}
