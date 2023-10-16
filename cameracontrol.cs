using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // ����ͷ�ƶ��ٶ�
    public float rotationSpeed = 2f; // ��ת�ٶ�

    private Camera mainCamera;
    private bool isRotating = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // ��ȡ�û�������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �����ƶ�����
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // ���ո����Ctrl�������룬���ݰ������ȷ���������½��ķ���
        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection.y += 1; // ����
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            moveDirection.y -= 1; // �½�
        }

        // ���������ƶ�����ͷ
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // ����м�����ʱ��ʼ��ת
        if (Input.GetMouseButtonDown(2))
        {
            isRotating = true;
        }

        // ����м��ͷ�ʱֹͣ��ת
        if (Input.GetMouseButtonUp(2))
        {
            isRotating = false;
        }

        // ���������ת����������X���ƶ���ת����ͷ
        if (isRotating)
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(Vector3.up * rotationX);
        }
    }
}