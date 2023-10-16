using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // 摄像头移动速度
    public float rotationSpeed = 2f; // 旋转速度

    private Camera mainCamera;
    private bool isRotating = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 获取用户的输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // 检查空格键和Ctrl键的输入，根据按键情况确定上升或下降的方向
        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection.y += 1; // 上升
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            moveDirection.y -= 1; // 下降
        }

        // 根据输入移动摄像头
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 鼠标中键按下时开始旋转
        if (Input.GetMouseButtonDown(2))
        {
            isRotating = true;
        }

        // 鼠标中键释放时停止旋转
        if (Input.GetMouseButtonUp(2))
        {
            isRotating = false;
        }

        // 如果正在旋转，根据鼠标的X轴移动旋转摄像头
        if (isRotating)
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(Vector3.up * rotationX);
        }
    }
}