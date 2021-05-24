using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private PCTRLTest playerCtrl;
    private UtilsForCamera cam;
    private PlayerInteraction playerInteraction;
    private GrabCollider grabCollider;
   
    [SerializeField] private GameObject grabButton;
    [SerializeField] private GameObject putButton;
    [SerializeField] private GameObject keepButton;
    [SerializeField] private GameObject keepOutButton;
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
    }
    public void BtnEvt_Up()
    {
        playerCtrl.InputUp = !playerCtrl.InputUp;
    }
    public void BtnEvt_Right()
    {
        playerCtrl.InputRight = !playerCtrl.InputRight;
    }
    public void BtnEvt_Down()
    {
        playerCtrl.InputDown = !playerCtrl.InputDown;
    }
    public void BtnEvt_UpLeft()
    {
        playerCtrl.InputUpLeft = !playerCtrl.InputUpLeft;
    }
    public void BtnEvt_UpRight()
    {
        playerCtrl.InputUpRight = !playerCtrl.InputUpRight;
    }
    public void BtnEvt_DownLeft()
    {
        playerCtrl.InputDownLeft = !playerCtrl.InputDownLeft;
    }
    public void BtnEvt_DownRight()
    {
        playerCtrl.InputDownRight = !playerCtrl.InputDownRight;
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
}
