using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Translates the camera
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 0, 0.01f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, 0, -0.01f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.position += new Vector3(0, 0.01f, 0);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position += new Vector3(0, -0.01f, 0);
            }
        }

        // Camera follows the mouse 
        if (Input.GetKey(KeyCode.LeftControl))
        {
            float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
            float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
            transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
        }
        
    }
}
