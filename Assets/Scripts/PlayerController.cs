using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float turnSpeed = 100;
    public float maxForwardSpeed = 8;

    const float groundAccel = 5;
    const float groundDecel = 30;

    public int currentLevel = 1;

    Vector2 moveDirection;
    //Vector2 lookDirection;
    //Vector2 lastLookDirection;

    //Animator anim;
    Rigidbody rb;

    float desiredSpeed;
    float forwardSpeed;
    float jumpDirection;
    float jumpSpeed = 30000f;
    float jumpEffort = 0;
    
    //float groundRayDist = 3f;
    //float xSensitivity = 0.5f;
    //float ySensitivity = 0.5f;

    //int health = 100;

    bool readyJump = false;
    bool onGround = true;
    //bool escapePressed = false;
    //bool cursorIsLocked = true;
    //bool firing = false;

    //public Transform weapon;
    //public Transform hand;
    //public Transform hip;
    //public Transform spine;
    //public LineRenderer laser;
    //public GameObject crossLight;
    //public bool isDead = false;

    public TextMeshProUGUI speedText;

    //public void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Bullet")
    //    {
    //        health -= 10;
    //        anim.SetTrigger("Hit");

    //        if (health <= 0)
    //        {
    //            isDead = true;
    //            anim.SetLayerWeight(1, 0);
    //            anim.SetBool("Dead", true);

    //            Cursor.lockState = CursorLockMode.None;
    //            Cursor.visible = true;
    //        }
    //    }
    //}


    bool IsMoveInput
    {
        get { return !Mathf.Approximately(moveDirection.sqrMagnitude, 0f); }
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    //public void OnLook(InputAction.CallbackContext context)
    //{
    //    lookDirection = context.ReadValue<Vector2>();

    //}

    public void OnJump(InputAction.CallbackContext context)
    {
        jumpDirection = context.ReadValue<float>();
    }

    
    //public void OnESC(InputAction.CallbackContext context)
    //{
    //    if ((int)context.ReadValue<float>() == 1)
    //    {
    //        escapePressed = true;
    //    }
    //    else
    //    {
    //        escapePressed = false;
    //    }
    //}

    
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

        //anim.SetFloat("ForwardSpeed", forwardSpeed);

        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);

        transform.Translate(direction.x * moveSpeed * Time.deltaTime , 0, direction.y * moveSpeed * Time.deltaTime);
    }

    void Jump(float direction)
    {
    //    //Debug.Log(direction);
        if (direction > 0 && onGround)
        {
    //        anim.SetBool("ReadyJump", true);
            readyJump = true;
            jumpEffort += Time.deltaTime;
        }
        else if (readyJump)
        {
    //        anim.SetBool("Launch", true);
            readyJump = false;
    //        anim.SetBool("ReadyJump", false);
            Launch();
        }
    }

    public void Launch()
    {
        rb.AddForce(0, jumpSpeed * Mathf.Clamp(jumpEffort, 1, 3), 0);
        rb.AddForce(this.transform.forward * forwardSpeed * 500);
        //    anim.SetBool("Launch", false);
        //    anim.applyRootMotion = false;
        onGround = false;
    }

    public void Land()
    {
        //    anim.SetBool("Land", false);
        //    anim.applyRootMotion = true;
        //    anim.SetBool("Launch", false);
        jumpEffort = 0;
    }
    
    void Start()
    {
        //anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    //public void UpdateCursorLock()
    //{
    //    if (escapePressed)
    //    {
    //        cursorIsLocked = false;
    //    }

    //    if (cursorIsLocked)
    //    {
    //        Cursor.lockState = CursorLockMode.Locked;
    //        Cursor.visible = false;
    //    }
    //    else
    //    {
    //        Cursor.lockState = CursorLockMode.None;
    //        Cursor.visible = true;
    //    }
    //}


    void Update()
    {
        //if (isDead) return;

        //UpdateCursorLock();
        Move(moveDirection);
        Jump(jumpDirection);

        //if (anim.GetBool("Armed"))
        //{
        //    laser.gameObject.SetActive(true);
        //    crossLight.gameObject.SetActive(true);

        //    RaycastHit laserHit;
        //    Ray laserRay = new Ray(laser.transform.position, laser.transform.forward);
        //    if (Physics.Raycast(laserRay, out laserHit))
        //    {
        //        laser.SetPosition(1, laser.transform.InverseTransformPoint(laserHit.point));
        //        crossLight.transform.localPosition = new Vector3(0, 0, laser.GetPosition(1).z * 0.9f);

        //        if (firing && laserHit.collider.gameObject.tag == "Orb")
        //        {
        //            laserHit.collider.gameObject.GetComponent<AIController>().BlowUp();
        //        }

        //    }
        //    else
        //    {
        //        crossLight.gameObject.SetActive(false);
        //    }
        //}
        //else
        //{
        //    laser.gameObject.SetActive(false);
        //    crossLight.gameObject.SetActive(false);
        //}

        //RaycastHit hit;
        //Ray ray = new Ray(transform.position + Vector3.up * groundRayDist * 0.5f, -Vector3.up);

        //if (Physics.Raycast(ray, out hit, groundRayDist))
        //{
        //    if (!onGround)
        //    {
        //        onGround = true;
        //        anim.SetFloat("LandingVelocity", rb.velocity.magnitude);
        //        //Debug.Log("Landing Velocity:" + rb.velocity.magnitude);
        //        anim.SetBool("Land", true);
        //        anim.SetBool("Falling", false);
        //    }
        //}
        //else
        //{
        //    onGround = false;
        //    anim.SetBool("Falling", true);
        //    anim.applyRootMotion = false;
        //}

        //Debug.DrawRay(transform.position + Vector3.up * groundRayDist * 0.5f, -Vector3.up * groundRayDist, Color.red);
    }

    void LateUpdate()
    {
        //if (isDead) return;

        //if (anim.GetBool("Armed"))
        //{
        //    lastLookDirection += new Vector2(-lookDirection.y * ySensitivity, lookDirection.x * xSensitivity);
        //    lastLookDirection.x = Mathf.Clamp(lastLookDirection.x, -20, 20);
        //    lastLookDirection.y = Mathf.Clamp(lastLookDirection.y, -20, 40);

        //    spine.localEulerAngles = lastLookDirection;
        //}
    }

    public void DisplaySpeed(float speedToDisplay)
    {
        speedText.text = string.Format("{0:00}", speedToDisplay);
    }
}
