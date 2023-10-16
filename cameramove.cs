using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    bool isDown = false;
    float rotSpeed = 10;

    // movement components
    private float moveSpeed = 4f;
    private float upDownSpeed = 3.0f;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Êó±êÖÐ¼üÐý×ª
        if (Input.GetMouseButtonDown(2))
        {
            isDown = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            isDown = false;
        }
        if (isDown)
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            Quaternion qx = Quaternion.AngleAxis(mx * rotSpeed, Vector3.up);
            Quaternion qy = Quaternion.AngleAxis(my * rotSpeed, Vector3.left);
            transform.rotation = transform.rotation * qx * qy;
        }
        Move();
    }

    // move
    public void Move()
    {
        //get the horizontal and vertical in number
        float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float vertical = Input.GetAxisRaw("Vertical") * moveSpeed;
        float upDown = Input.GetKey(KeyCode.Space) ? upDownSpeed : Input.GetKey(KeyCode.LeftControl) ? -upDownSpeed : 0;
        // direction in a normalized vector
        Vector3 movementDirection = new Vector3(horizontal, upDown, vertical);
        transform.Translate(movementDirection * Time.deltaTime);
    }



}
