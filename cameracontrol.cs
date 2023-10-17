using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // Camera movement speed
    public float rotationSpeed = 2f; // rotation speed

    private Camera mainCamera;
    private bool isRotating = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Getting user input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the direction of movement
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Check the spacebar and Ctrl key inputs to determine the direction of ascent or descent based on keystrokes
        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection.y += 1; // go upward
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            moveDirection.y -= 1; // go down
        }

        // Move the camera according to the input
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Spinning starts when the middle mouse button is pressed
        if (Input.GetMouseButtonDown(2))
        {
            isRotating = true;
        }

        // Stop rotating when the middle mouse button is released
        if (Input.GetMouseButtonUp(2))
        {
            isRotating = false;
        }

        // If it is rotating, move the rotating camera according to the X axis of the mouse
        if (isRotating)
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(Vector3.up * rotationX);
        }
    }
}
