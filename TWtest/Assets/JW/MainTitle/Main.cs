﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    [SerializeField] private Button startbtn;
    [SerializeField] private Button setting;
    [SerializeField] private Image title;
    private Transform startposition;
    private RectTransform startbtnposition;
    private RectTransform settingbtnposition;
    private RectTransform rt3;
    private RectTransform rt4;
    private bool touchOn;
    private bool skip;

    // Start is called before the first frame update
    void Start()
    {
        skip = false;
        startposition = Camera.GetComponent<Transform>();

        touchOn = false;

        rt3 = startbtn.GetComponent<RectTransform>();
        rt4 = setting.GetComponent<RectTransform>();

        Mainscene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && skip == false)    //Input.touchCount > 0으로 바꾸기(터치)
        {
            Time.timeScale = 50f;
            Invoke("Skip", 50f);
            skip = true;
        }
    }
    void Mainscene()
    {
        Color color = title.GetComponent<Image>().color;
        color.a = 0;
        title.GetComponent<Image>().color = color;

        rt3.DOAnchorPosX(-430, 0);
        rt4.DOAnchorPosX(-430, 0);

        startposition.position = new Vector3(0, 30, -30);

        Camera.transform.DOMoveY(0, 5);
        title.DOFade(1, 5);
        rt3.DOAnchorPosX(-204, 3).SetDelay(5.3f);
        rt4.DOAnchorPosX(-204, 3).SetDelay(5.3f);
    }
    void Skip()
    {
        Time.timeScale = 1f;
    }
}
