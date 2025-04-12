using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 5f, mouseSensitivity = 100f, jumpForace = 5f, groundDistance = 0.4f, crouchHT = 0.5f;
    public Transform cameraTransform, onGround;
    public LayerMask groundMask;

    private float xRotation = 0f;
    private bool isGround;
    private Rigidbody rb;
    private Vector3 ogScale;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Hides the cursor & locks it to the center of the screen
        rb = GetComponent<Rigidbody>();
        ogScale = transform.localScale;
    }
    void Update()
    {
        //Check Ground
        isGround = Physics.CheckSphere(onGround.position, groundDistance, groundMask);

        //Mouse Look Around (Check how much mouse has moved)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        transform.position += move * speed * Time.deltaTime;

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGround) rb.AddForce(Vector3.up * jumpForace, ForceMode.Impulse);

        //Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl)) transform.localScale = new Vector3(ogScale.x, crouchHT, ogScale.z);
        if (Input.GetKeyUp(KeyCode.LeftControl)) transform.localScale = ogScale;

    }
}
