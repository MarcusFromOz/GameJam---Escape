using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float turnSpeed = 100;
    public float maxForwardSpeed = 15;

    const float groundAccel = 20;
    const float groundDecel = 30;

    public int currentLevel = 1;

    Vector2 moveDirection;

    Animator anim;
    Rigidbody rb;

    float desiredSpeed;
    float forwardSpeed;
    float jumpDirection;
    float jumpSpeed = 3000f;
    float jumpEffort = 0;
    float groundRayDist = 3f;

    bool readyJump = false;
    bool onGround = true;

    public bool isDead = false;

    public TextMeshProUGUI speedText;

    //public void OnCollisionEnter(Collision col)
    //{
    //            isDead = true;
    //}


    bool IsMoveInput
    {
        get { return !Mathf.Approximately(moveDirection.sqrMagnitude, 0f); }
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }
        
    public void OnJump(InputAction.CallbackContext context)
    {
        jumpDirection = context.ReadValue<float>();
    }

    
    void Move(Vector2 direction)
    {
        float turnAmount = direction.x;
        float fDirection = direction.y;

        if (direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }

        desiredSpeed = direction.magnitude * maxForwardSpeed * Mathf.Sign(fDirection);
        float acceleration = IsMoveInput ? groundAccel : groundDecel;

        forwardSpeed = Mathf.MoveTowards(forwardSpeed, desiredSpeed, acceleration * Time.deltaTime);

        anim.SetFloat("ForwardSpeed", forwardSpeed * 5.0f);

        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);

    }

    void Jump(float direction)
    {
        if (direction > 0 && onGround)
        {
            anim.SetBool("ReadyJump", true);
            readyJump = true;
            jumpEffort += Time.deltaTime;
        }
        else if (readyJump)
        {
            anim.SetBool("Launch", true);
            readyJump = false;
            anim.SetBool("ReadyJump", false);
        }
    }

    public void Launch()
    {
        rb.AddForce(0, jumpSpeed * Mathf.Clamp(jumpEffort, 1, 3f), 0);
        rb.AddForce(this.transform.forward * forwardSpeed * 300);
        anim.SetBool("Launch", false);
        anim.applyRootMotion = false;
        onGround = false;
    }

    public void Land()
    {
        anim.SetBool("Land", false);
        anim.applyRootMotion = true;
        anim.SetBool("Launch", false);
        jumpEffort = 0;
    }
    
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (isDead) return;

        Move(moveDirection);
        Jump(jumpDirection);

        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up * groundRayDist * 0.5f, -Vector3.up);

        if (Physics.Raycast(ray, out hit, groundRayDist))
        {
            if (!onGround)
            {
                onGround = true;
                anim.SetBool("Land", true);
                anim.SetBool("Falling", false);
            }
        }
        else
        {
            onGround = false;
            anim.SetBool("Falling", true);
            anim.applyRootMotion = false;
        }

        //Debug.DrawRay(transform.position + Vector3.up * groundRayDist * 0.5f, -Vector3.up * groundRayDist, Color.red);
    }

    
    public void DisplaySpeed(float speedToDisplay)
    {
        speedText.text = string.Format("{0:00}", speedToDisplay);
    }
}
