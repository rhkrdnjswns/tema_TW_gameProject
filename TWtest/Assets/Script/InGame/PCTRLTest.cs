using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTRLTest : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private Vector3 forward;
    private Vector3 right;
    [SerializeField] private BoxCollider jumpCollider;

    #region ==Input Action==
    private bool inputLeft = false;
    private bool inputRight = false;
    private bool inputUp = false;
    private bool inputDown = false;
    private bool inputUpLeft = false;
    private bool inputUpRight = false;
    private bool inputDownLeft = false;
    private bool inputDownRight = false;
    private bool isJumpClick = false;
    #endregion

    [SerializeField] private bool isJump = false;
    private float pressTime = 0f;
    [SerializeField] private Rigidbody rigidbody;

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
    public float PressTime { get => pressTime; set => pressTime = value; }
    public bool IsJump { get => isJump; set => isJump = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
       
    }
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
        if (isJumpClick)
        {
            pressTime += Time.deltaTime;
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            ScoreManager.Instance.ResetScore();
        }
#endif

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
    public void TryJump()
    {
        isJumpClick = true;
    }
    public void Jump()
    {
        if (!isJump)
        {
            isJump = true;
            if (pressTime <= 1)
            {
                if(rigidbody!=null)
                    rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("1초 넘음");
                if (rigidbody != null)
                    rigidbody.AddForce(Vector3.up * 6.5f, ForceMode.Impulse);
            }

            Invoke("SetJumpColliderForInvoke", 0.1f);
            isJumpClick = false;
            pressTime = 0f;
        }
        else
        {
            pressTime = 0f;
        }
    }
    private void SetJumpColliderForInvoke()
    {  
        jumpCollider.enabled = true;
    }
}
