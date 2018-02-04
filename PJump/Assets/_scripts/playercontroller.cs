using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {
    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    Transform cameraT;
    float verticalLookRotation;
    public float walkSpeed=8f;
    public RigidbodyInterpolation interpolation;
    Rigidbody rb;
    gravityattractor planet;
    Vector3 moveAmount;
    Vector3 smoothMoveV;

    private float counter = 0f;
    public float jumptimer = 2f;


    public float grounddistance = 1f;
    public float jump = 10f;
   

    // Use this for initialization
    void Start () {
        cameraT = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        planet = GameObject.FindGameObjectWithTag("planet").GetComponent<gravityattractor>();
        counter += Time.deltaTime;
        //horizontal look
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        //vertical look
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -89, 50);
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;
        //movement
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveV, 0.15f);
        //jump
        if (Input.GetAxisRaw("Jump") > 0 & counter > jumptimer)
        {
            if (IsGrounded() == true)
            {
                rb.AddForce((planet.transform.position - transform.position).normalized * -jump, ForceMode.Impulse);
                Debug.Log("Jump!" + counter);
                counter = 0f;
            }
        }

        //shoot
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(-planet.targetDir);
        }
        //apply forces
        rb.MovePosition(rb.transform.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, (planet.transform.position - transform.position).normalized, grounddistance + 0.2f);
    }
}
