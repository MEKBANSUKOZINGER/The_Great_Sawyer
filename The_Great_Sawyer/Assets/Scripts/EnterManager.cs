using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnterManager : MonoBehaviour
{
    private bool Entered = false;
    private bool firstAnim = false;

    public Image Logo;
    public TextMeshProUGUI TouchToStart;
    public Image temp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !Entered && firstAnim)
        {
            Logo.DOFade(0.0f, 1.0f);
            TouchToStart.DOFade(0.0f, 1.0f);
            Entered = true;
            temp.rectTransform.DOMoveY(1716f, 0.5f).SetDelay(1.5f).SetEase(Ease.InOutSine);
        }
    }

    public void firstAnimBool()
    {
        firstAnim = true;
    }
}
