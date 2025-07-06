using UnityEngine;

public class FlyThroughCamera : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float boostMultiplier = 2f;

    [Header("Look Settings")]
    public float lookSensitivity = 2f;
    public float rotationSmoothing = 5f;

    private Vector2 currentRotation;
    private Vector2 targetRotation;

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 euler = transform.eulerAngles;
        targetRotation = currentRotation = new Vector2(euler.y, euler.x);
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        targetRotation.x += mouseX;
        targetRotation.y -= mouseY;
        targetRotation.y = Mathf.Clamp(targetRotation.y, -89f, 89f); // Prevent flipping

        currentRotation = Vector2.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSmoothing);
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);
    }

    void HandleMovement()
    {
        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= boostMultiplier;
        }

        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += transform.forward;
        if (Input.GetKey(KeyCode.S)) direction -= transform.forward;
        if (Input.GetKey(KeyCode.A)) direction -= transform.right;
        if (Input.GetKey(KeyCode.D)) direction += transform.right;
        if (Input.GetKey(KeyCode.E)) direction += transform.up;
        if (Input.GetKey(KeyCode.Q)) direction -= transform.up;

        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
