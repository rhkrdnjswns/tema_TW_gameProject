using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsForCamera : MonoBehaviour
{
    [SerializeField] private Camera centerCam;
    [SerializeField] private Camera backCam;
    [SerializeField] private Camera currentCam;
    private bool isBack = false;

    private PCTRLTest playerCtrl;

    public Camera CenterCam { get => centerCam; set => centerCam = value; }
    public Camera BackCam { get => backCam; set => backCam = value; }
    public Camera CurrentCam { get => currentCam; set => currentCam = value; }
    public bool IsBack { get => isBack; set => isBack = value; }

    private void Awake()
    {
        playerCtrl = FindObjectOfType<PCTRLTest>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeCamera(CenterCam);
    }
    public void ChangeCamera(Camera cam)
    {
        if (CurrentCam != null && CurrentCam.gameObject.activeSelf == true)
        {
            CurrentCam.gameObject.SetActive(false);
        }
        cam.gameObject.SetActive(true);
        if(playerCtrl != null)
        {
            var forward = playerCtrl.Forward;
            forward = cam.transform.forward;
            forward.y = 0;
            forward = Vector3.Normalize(forward);
            playerCtrl.Forward = forward;

            playerCtrl.Right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
            CurrentCam = cam;
        }
        
    }

}
