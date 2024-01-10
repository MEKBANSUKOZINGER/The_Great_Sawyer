using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public static string nextScene;
    [SerializeField] Image progressBar;
    [SerializeField] TextMeshProUGUI tipText;

    private int randInt = -1;
    private string[] tipTexts = {"하늘소 호는 가로 길이가 무려 300미터입니다!\n정말 거대하지 않나요?",
                                    "하늘소 호의 카페에서 파는 구름 라떼는\n헤이즐넛 맛이 난답니다.",
                                    "교환권으로 유료 재화들을 교환할 수 있습니다!",
                                    "카베르나는 1960년에 의문의 폭발로 인해\n생긴 도시입니다.",
                                    "스티머에서 증기기관이 처음 발명되었습니다.",
                                    "한울의 어원은 순우리말 \"한울\"로,\n우주의 순우리말입니다.",
                                    "플라미아에 있는 '꺼지지 않는 불꽃'은 \n 200년 넘게 타오르고 있습니다!"};
    void Start()
    {
        randInt = Random.Range(0, tipTexts.Length);
        tipText.text = tipTexts[randInt];
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            int curRand = Random.Range(0, tipTexts.Length);
            while (curRand == randInt)
            {
                curRand = Random.Range(0, tipTexts.Length);
            }
            tipText.text = tipTexts[curRand];
            randInt = curRand;
        }
    }
    
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            Debug.Log(progressBar.fillAmount);
            timer += Time.deltaTime;
            if (op.progress <0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress )
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield return new WaitForSeconds(2.0f);
                    yield break;
                }
            }
        }
    }
}
