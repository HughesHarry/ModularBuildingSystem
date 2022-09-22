using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                Camera.transform.position += new Vector3(0, 0, 0.01f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Camera.transform.position += new Vector3(0, 0, -0.01f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Camera.transform.position += new Vector3(-0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Camera.transform.position += new Vector3(0.01f, 0, 0);
            }
            if (Input.GetKey(KeyCode.E))
            {
                Camera.transform.position += new Vector3(0, 0.01f, 0);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Camera.transform.position += new Vector3(0, -0.01f, 0);
            }
        }
    }
}
