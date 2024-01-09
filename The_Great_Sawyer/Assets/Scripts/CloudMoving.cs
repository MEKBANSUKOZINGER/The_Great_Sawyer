using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloudMoving : MonoBehaviour
{
    private RectTransform rt;

    private Vector3 returnPos = new Vector3(1620f, 960f, 0f);
    private Vector3 endPos = new Vector3(-1610f, 0f, 0f);
    private Vector3 firstFloorSpeed = new Vector3(3f, 0f, 0f);
    private Vector3 secondFloorSpeed = new Vector3(2.5f, 0f, 0f);
    private Vector3 thirdFloorSpeed = new Vector3(2f, 0f, 0f);
    private Vector3 fourthFloorSpeed = new Vector3(1.5f, 0f, 0f);
    private Vector3 fifthFloorSpeed = new Vector3(1f, 0f, 0f);
    private Vector3 sixthFloorSpeed = new Vector3(0.25f, 0f, 0f);

    public int n;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rt.position.x <= endPos.x)
        {
            rt.position = returnPos;
        } 
        else if(n == 1)
        {
            rt.position -= firstFloorSpeed;
        }
        else if (n == 2)
        {
            rt.position -= secondFloorSpeed;
        }
        else if (n == 3)
        {
            rt.position -= thirdFloorSpeed;
        }
        else if (n == 4)
        {
            rt.position -= fourthFloorSpeed;
        }
        else if (n == 5)
        {
            rt.position -= fifthFloorSpeed;
        }
        else if (n == 6)
        {
            rt.position -= sixthFloorSpeed;
        }
    }
}
