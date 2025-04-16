using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    Animator anim;
    public float speed = 5f, mouseSensitivity = 100f, jumpForace = 5f, groundDistance = 0.4f, crouchHT = 0.5f;
    public Transform cameraTransform, onGround;
    public LayerMask groundMask;

    private float xRotation = 0f;
    private bool isGround;
    private Rigidbody rb;
    private Vector3 ogScale;
    public bool enableMovement, enableMouse;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked; //Hides the cursor & locks it to the center of the screen
        rb = GetComponent<Rigidbody>();
        ogScale = transform.localScale;
        anim = GetComponentInChildren<Animator>();
        enableMovement = true; 
        enableMouse = true;
    }
    void Update() {
        float horizontal = Input.GetAxis("Horizontal"), vertical = Input.GetAxis("Vertical");
        float moveAmount = new Vector2(horizontal, vertical).magnitude;
        anim.SetFloat("Speed", moveAmount);
        anim.SetBool("isJumping", !isGround);

        if (Input.GetKey(KeyCode.LeftControl)) anim.SetBool("isCrouching", true);
        else anim.SetBool("isCrouching", false);
    }

    void FixedUpdate() {
        //Check Ground
        isGround = Physics.CheckSphere(onGround.position, groundDistance, groundMask);

        if (enableMouse == true) {
            //Mouse Look Around (Check how much mouse has moved)
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime, mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, mouseX, 0f));
        }


        if (enableMovement == true) {
            // Movement
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            rb.MovePosition(rb.position + move * speed * Time.deltaTime);

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && isGround) {
                rb.AddForce(Vector3.up * jumpForace, ForceMode.Impulse);
                anim.SetBool("isJumping", true);
            }
            if (isGround && anim.GetBool("isJumping")) anim.SetBool("isJumping", false);
            //Crouch
            if (Input.GetKeyDown(KeyCode.LeftControl)) transform.localScale = new Vector3(ogScale.x, crouchHT, ogScale.z);
            if (Input.GetKeyUp(KeyCode.LeftControl)) transform.localScale = ogScale;

        }

    }
}
