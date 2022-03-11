using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTRLTest : MonoBehaviour
{
    public float moveSpeed = 4f;
    Vector3 forward;
    Vector3 right;

    private bool inputLeft = false;
    private bool inputRight = false;
    private bool inputUp = false;
    private bool inputDown = false;
    private bool inputUpLeft = false;
    private bool inputUpRight = false;
    private bool inputDownLeft = false;
    private bool inputDownRight = false;

    public Camera centerCam;
    public Camera backCam;
    public Camera currentCam;
    private bool isBack = false;
    // Start is called before the first frame update
    void Start()
    {
        CameraChange(centerCam);
    }
    void CameraChange(Camera cam)
    {
        if (currentCam != null && currentCam.gameObject.activeSelf == true)
        {
            currentCam.gameObject.SetActive(false);
        }
        cam.gameObject.SetActive(true);
        forward = cam.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        currentCam = cam;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentCam == centerCam)
                CameraChange(backCam);
            else
                CameraChange(centerCam);
        }
        if(inputLeft == true)
        {
            MoveLeft();
        }
        else if(inputUp == true)
        {
            MoveUp();
        }
        else if(inputRight == true)
        {
            MoveRight();
        }
        else if(inputDown == true)
        {
            MoveDown();
        }
        else if(inputUpLeft == true)
        {
            MoveUpLeft();
        }
        else if(inputUpRight == true)
        {
            MoveUpRight();
        }
        else if(inputDownLeft == true)
        {
            MoveDownLeft();
        }
        else if(inputDownRight == true)
        {
            MoveDownRight();
        }
    }
    public void SetInputLeft()
    {
        inputLeft = !inputLeft;
    }

    private void MoveLeft()
    {
        Vector3 RightMovement = right * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 direction = Vector3.Normalize(RightMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += RightMovement;
        }
    }
    public void SetInputRight()
    {
        inputRight = !inputRight;
    }
    private void MoveRight()
    {
        Vector3 RightMovement = right * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 direction = Vector3.Normalize(RightMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += RightMovement;
        }
    }
    public void SetInputUp()
    {
        inputUp = !inputUp;
    }
    private void MoveUp()
    {
        Vector3 ForwardMovement = forward * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 direction = Vector3.Normalize(ForwardMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += ForwardMovement;
        }
    }
    public void SetInputDown()
    {
        inputDown = !inputDown;
    }
    private void MoveDown()
    {
        Vector3 ForwardMovement = forward * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 direction = Vector3.Normalize(ForwardMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += ForwardMovement;
        }
    }
    public void SetInputUpLeft()
    {
        inputUpLeft = !inputUpLeft;
    }
    private void MoveUpLeft()
    {
        Vector3 RightMovement = right * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 ForwardMovement = forward * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 FinalMovement = ForwardMovement + RightMovement;
        Vector3 direction = Vector3.Normalize(FinalMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += FinalMovement;
        }
    }
    public void SetInputUpRight()
    {
        inputUpRight = !inputUpRight;
    }
    private void MoveUpRight()
    {
        Vector3 RightMovement = right * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 ForwardMovement = forward * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 FinalMovement = ForwardMovement + RightMovement;
        Vector3 direction = Vector3.Normalize(FinalMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += FinalMovement;
        }
    }
    
    public void SetInputDownLeft()
    {
        inputDownLeft = !inputDownLeft;
    }
    private void MoveDownLeft()
    {
        Vector3 RightMovement = right * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 ForwardMovement = forward * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 FinalMovement = ForwardMovement + RightMovement;
        Vector3 direction = Vector3.Normalize(FinalMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += FinalMovement;
        }
    }
    public void SetInputDownRight()
    {
        inputDownRight = !inputDownRight;
    }
    private void MoveDownRight()
    {
        Vector3 RightMovement = right * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 ForwardMovement = forward * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 FinalMovement = ForwardMovement + RightMovement;
        Vector3 direction = Vector3.Normalize(FinalMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += FinalMovement;
        }
    }
  
}
