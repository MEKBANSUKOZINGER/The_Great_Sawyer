using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CloudMoving : MonoBehaviour
{
    private RectTransform rt;

    private Vector3 returnPos = new Vector3(810f, 0f, 0f);
    private Vector3 firstFloorSpeed = new Vector3(10f, 0f, 0f);
    private Vector3 secondFloorSpeed = new Vector3(7.4f, 0f, 0f);
    private Vector3 thirdFloorSpeed = new Vector3(4.4f, 0f, 0f);
    private Vector3 fourthFloorSpeed = new Vector3(2.4f, 0f, 0f);
    private Vector3 fifthFloorSpeed = new Vector3(1.9f, 0f, 0f);
    private Vector3 sixthFloorSpeed = new Vector3(0.3f, 0f, 0f);

    public int n;
    public Image bumper;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        returnPos.y = rt.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (rt.position.x <= bumper.rectTransform.position.x)
        {
            rt.position = returnPos;
        } 
        else if(n == 1)
        {
            rt.position -= firstFloorSpeed * Time.deltaTime * 10;
        }
        else if (n == 2)
        {
            rt.position -= secondFloorSpeed * Time.deltaTime * 10;
        }
        else if (n == 3)
        {
            rt.position -= thirdFloorSpeed * Time.deltaTime * 10;
        }
        else if (n == 4)
        {
            rt.position -= fourthFloorSpeed * Time.deltaTime * 10;
        }
        else if (n == 5)
        {
            rt.position -= fifthFloorSpeed * Time.deltaTime * 10;
        }
        else if (n == 6)
        {
            rt.position -= sixthFloorSpeed * Time.deltaTime * 10;
        }
    }
}
