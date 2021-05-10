using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private PCTRLTest playerCtrl;
    private UtilsForCamera cam;
    private void Awake()
    {
        playerCtrl = FindObjectOfType<PCTRLTest>();
        cam = FindObjectOfType<UtilsForCamera>();    
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
}
