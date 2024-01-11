using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    private bool Entered = false;
    private bool firstAnim = false;

    public Image semiWhite;
    public Image semiWhite_2;
    public Image white;
    public Image realWhite;

    public List<Image> trainContainer = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !Entered && firstAnim)
        {
            Entered = true;
            for(int i = 0; i < trainContainer.Count; i++)
            {
                trainContainer[i].rectTransform.DOMoveX(trainContainer[i].rectTransform.position.x + 3000f, 1.5f).SetEase(Ease.InCirc);
            }
            semiWhite.rectTransform.DOMoveX(-1080f, 0.75f).SetEase(Ease.InSine);
            semiWhite_2.rectTransform.DOMoveX(-1080f, 1f).SetEase(Ease.InSine);
            white.rectTransform.DOMoveX(-1080f, 1f).SetEase(Ease.InSine).SetDelay(0.5f);
            realWhite.rectTransform.DOMoveX(540f, 1f).SetEase(Ease.InSine).SetDelay(0.5f).OnComplete(toMain);
        }
    }

    public void firstAnimBool()
    {
        firstAnim = true;
    }

    private void toMain()
    {
        Loading.LoadScene("main");
    }
}
