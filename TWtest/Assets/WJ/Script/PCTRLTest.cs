﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTRLTest : MonoBehaviour
{
   

    [SerializeField] private float moveSpeed = 4f;
    private Vector3 forward;
    private Vector3 right;

    private bool inputLeft = false;
    private bool inputRight = false;
    private bool inputUp = false;
    private bool inputDown = false;
    private bool inputUpLeft = false;
    private bool inputUpRight = false;
    private bool inputDownLeft = false;
    private bool inputDownRight = false;

    public bool InputLeft { get => inputLeft; set => inputLeft = value; }
    public bool InputRight { get => inputRight; set => inputRight = value; }
    public bool InputUp { get => inputUp; set => inputUp = value; }
    public bool InputDown { get => inputDown; set => inputDown = value; }
    public bool InputUpLeft { get => inputUpLeft; set => inputUpLeft = value; }
    public bool InputUpRight { get => inputUpRight; set => inputUpRight = value; }
    public bool InputDownLeft { get => inputDownLeft; set => inputDownLeft = value; }
    public bool InputDownRight { get => inputDownRight; set => inputDownRight = value; }
    public Vector3 Forward { get => forward; set => forward = value; }
    public Vector3 Right { get => right; set => right = value; }

    // Start is called before the first frame update
    void Start()
    {
        

    }
   
    // Update is called once per frame
    void Update()
    {
   
        if(InputLeft == true)
        {
            MoveLeft();
        }
        else if(InputUp == true)
        {
            MoveUp();
        }
        else if(InputRight == true)
        {
            MoveRight();
        }
        else if(InputDown == true)
        {
            MoveDown();
        }
        else if(InputUpLeft == true)
        {
            MoveUpLeft();
        }
        else if(InputUpRight == true)
        {
            MoveUpRight();
        }
        else if(InputDownLeft == true)
        {
            MoveDownLeft();
        }
        else if(InputDownRight == true)
        {
            MoveDownRight();
        }
    }

    private void MoveLeft()
    {
        Vector3 RightMovement = Right * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 direction = Vector3.Normalize(RightMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += RightMovement;
        }
    }

    private void MoveRight()
    {
        Vector3 RightMovement = Right * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 direction = Vector3.Normalize(RightMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += RightMovement;
        }
    }

    private void MoveUp()
    {
        Vector3 ForwardMovement = Forward * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 direction = Vector3.Normalize(ForwardMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += ForwardMovement;
        }
    }

    private void MoveDown()
    {
        Vector3 ForwardMovement = Forward * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 direction = Vector3.Normalize(ForwardMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += ForwardMovement;
        }
    }

    private void MoveUpLeft()
    {
        Vector3 RightMovement = Right * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 ForwardMovement = Forward * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 FinalMovement = ForwardMovement + RightMovement;
        Vector3 direction = Vector3.Normalize(FinalMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += FinalMovement;
        }
    }

    private void MoveUpRight()
    {
        Vector3 RightMovement = Right * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 ForwardMovement = Forward * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 FinalMovement = ForwardMovement + RightMovement;
        Vector3 direction = Vector3.Normalize(FinalMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += FinalMovement;
        }
    }
    

    private void MoveDownLeft()
    {
        Vector3 RightMovement = Right * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 ForwardMovement = Forward * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 FinalMovement = ForwardMovement + RightMovement;
        Vector3 direction = Vector3.Normalize(FinalMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += FinalMovement;
        }
    }

    private void MoveDownRight()
    {
        Vector3 RightMovement = Right * moveSpeed * Time.smoothDeltaTime * 1;
        Vector3 ForwardMovement = Forward * moveSpeed * Time.smoothDeltaTime * -1;
        Vector3 FinalMovement = ForwardMovement + RightMovement;
        Vector3 direction = Vector3.Normalize(FinalMovement);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            transform.position += FinalMovement;
        }
    }
  
}
