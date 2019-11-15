using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameController gameController;

    [Header("Move Settings")]
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float sprintSpeed = 10f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Camera cameraObj;
    private float speed;
    float horizontalMove;
    float verticalMove;

    [Header("Camera Settings")]
    public float mouseSensitivity = 10;
    public Vector2 pitchMinMax = new Vector2(-30, 85);
    public float acceleration = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float yaw;
    float pitch;

    public bool InvertPitch;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        controller = GetComponent<CharacterController>();
        cameraObj = Camera.main;

        yaw = cameraObj.transform.eulerAngles.y;
        pitch = cameraObj.transform.eulerAngles.x;
        currentRotation = cameraObj.transform.eulerAngles;
    }

    void Update()
    {
        #region Movement
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");



        if (Input.GetKey(KeyCode.LeftShift) && controller.isGrounded)
        {
            speed = sprintSpeed;
        }
        else if (speed == sprintSpeed && !controller.isGrounded)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = moveSpeed;
        }

        if (controller.isGrounded)
        {
            // move direction directly from axes
            float moveY = moveDirection.y;
            moveDirection = new Vector3(horizontalMove, 0, verticalMove);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
            moveDirection.y = moveY;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;

            }


        }



        #region Camera
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        if (InvertPitch)
            pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
        else
            pitch += Input.GetAxis("Mouse Y") * -mouseSensitivity;

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, acceleration);

        transform.eulerAngles = currentRotation;
        #endregion

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
        #endregion

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 5);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Character"))
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("User input detected!");
                if (gameController.CompareWithTheOne(hit.collider.gameObject))
                {
                    // WIN
                }
                else
                {
                    // LOSE
                }
            }
        }
    }

}
