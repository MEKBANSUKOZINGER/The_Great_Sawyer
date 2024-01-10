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
    private string[] tipTexts = {"�ϴü� ȣ�� ���� ���̰� ���� 300�����Դϴ�!\n���� �Ŵ����� �ʳ���?",
                                    "�ϴü� ȣ�� ī�信�� �Ĵ� ���� �󶼴�\n������� ���� ����ϴ�.",
                                    "��ȯ������ ���� ��ȭ���� ��ȯ�� �� �ֽ��ϴ�!",
                                    "ī�������� 1960�⿡ �ǹ��� ���߷� ����\n���� �����Դϴ�.",
                                    "��Ƽ�ӿ��� �������� ó�� �߸�Ǿ����ϴ�.",
                                    "�ѿ��� ����� ���츮�� \"�ѿ�\"��,\n������ ���츮���Դϴ�.",
                                    "�ö�̾ƿ� �ִ� '������ �ʴ� �Ҳ�'�� \n 200�� �Ѱ� Ÿ������ �ֽ��ϴ�!"};
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
