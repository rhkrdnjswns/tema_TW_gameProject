﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private PCTRLTest playerCtrl;
    private UtilsForCamera cam;
    private PlayerInteraction playerInteraction;
    private GrabCollider grabCollider;
    
    [SerializeField] private GameObject gameOver;    
    [SerializeField] private GameObject grabButton;
    [SerializeField] private GameObject putButton;
    [SerializeField] private GameObject keepButton;
    [SerializeField] private GameObject keepOutButton;
    [SerializeField] private GameObject warningMsg;
    [SerializeField] private GameObject pauseWindow;

    private bool isPause;

    private void Awake()
    {
        grabCollider = FindObjectOfType<GrabCollider>();
        playerCtrl = FindObjectOfType<PCTRLTest>();
        cam = FindObjectOfType<UtilsForCamera>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();
       
    }

    public void BtnEvt_Left()
    {
        playerCtrl.InputLeft = !playerCtrl.InputLeft;
        playerInteraction.IsPutPossiable = false;
    }
    public void BtnEvt_Up()
    {
        playerCtrl.InputUp = !playerCtrl.InputUp;
        playerInteraction.IsPutPossiable = false;
    }
    public void BtnEvt_Right()
    {
        playerCtrl.InputRight = !playerCtrl.InputRight;
        playerInteraction.IsPutPossiable = false;
    }
    public void BtnEvt_Down()
    {
        playerCtrl.InputDown = !playerCtrl.InputDown;
        playerInteraction.IsPutPossiable = false;
    }
    public void BtnEvt_UpLeft()
    {
        playerCtrl.InputUpLeft = !playerCtrl.InputUpLeft;
        playerInteraction.IsPutPossiable = true;
    }
    public void BtnEvt_UpRight()
    {
        playerCtrl.InputUpRight = !playerCtrl.InputUpRight;
        playerInteraction.IsPutPossiable = true;
    }
    public void BtnEvt_DownLeft()
    {
        playerCtrl.InputDownLeft = !playerCtrl.InputDownLeft;
        playerInteraction.IsPutPossiable = true;
    }
    public void BtnEvt_DownRight()
    {
        playerCtrl.InputDownRight = !playerCtrl.InputDownRight;
        playerInteraction.IsPutPossiable = true;
    }
    public void BtnEvt_CameraChange()
    {
        if (cam.CurrentCam == cam.CenterCam)
            cam.ChangeCamera(cam.BackCam);
        else
            cam.ChangeCamera(cam.CenterCam);
    }
    public void BtnEvt_GrabBlock()
    {
        if (!playerCtrl.IsJump)
        {
            if (grabCollider.IsTriggerBlock)
            {
                playerInteraction.GrabBlock();
                grabButton.SetActive(false);
                putButton.SetActive(true);
            }
        }
    }
    public void BtnEvt_PutBlock()
    {
        if (!playerCtrl.IsJump)
        {
            if (playerInteraction.IsGrab)
            {
                playerInteraction.PutBlock();
                if (playerInteraction.IsPut)
                {
                    putButton.SetActive(false);
                    grabButton.SetActive(true);
                    playerInteraction.IsPut = false;
                }
            }
        }
    }
    public void BtnEvt_RotateX()
    {
        if (!playerCtrl.IsJump)
            playerInteraction.RotateBlockX();
    }
    public void BtnEvt_RotateY()
    {
        if (!playerCtrl.IsJump)
            playerInteraction.RotateBlockY();
    }
    public void BtnEvt_RotateZ()
    {
        if (!playerCtrl.IsJump)
            playerInteraction.RotateBlockZ();
    }
    public void BtnEvt_Keep()
    {
        if (!playerCtrl.IsJump)
        {
            if (playerInteraction.KeepBlock())
            {
                putButton.SetActive(false);
                grabButton.SetActive(true);
                keepButton.SetActive(false);
                keepOutButton.SetActive(true);
            }
        }
    }
    public void BtnEvt_KeepOut()
    {
        if (!playerCtrl.IsJump)
        {
            if (playerInteraction.KeepOut())
            {
                keepOutButton.SetActive(false);
                keepButton.SetActive(true);
                grabButton.SetActive(false);
                putButton.SetActive(true);
            }
        }
           
    }
    public void BtnEvt_Pause()
    {
        if (isPause == false)
        {
            Time.timeScale = 0;
            pauseWindow.gameObject.SetActive(true);
            isPause = true;
        }
        else if (isPause == true)
        {
            Time.timeScale = 1;
            pauseWindow.gameObject.SetActive(false);
            isPause = false;
        }
    }
    public void BtnEvt_ReStart()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadGameScene();
    }
    public void BtnEvt_Exit()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadMainScene();
    }
    public void GameOver()
    {
        SoundManager.Instance.StopSound();
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ActiveWarningMsg()
    {
        warningMsg.SetActive(true);
        Invoke("ActiveFalseWarningMsgForInvoke", 3f);
    }
    private void ActiveFalseWarningMsgForInvoke()
    {       
        warningMsg.SetActive(false);
    }
    
}