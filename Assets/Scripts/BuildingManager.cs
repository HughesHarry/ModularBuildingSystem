using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject newObject;

    private Vector3 position;
    private RaycastHit hit;
    private float rayRange = 1000;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask layerMaskObject;
    private bool objectClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { AddObject(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { AddObject(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { AddObject(2); }

        if (Input.GetMouseButtonDown(1))
        {
            objectClicked = true;
        }

        if (newObject != null)
        {
            newObject.transform.position = position;

            // Rotate object when key is pressed
            if (Input.GetKeyDown(KeyCode.W)) { RotateObject(Vector3.right, 45); }
            if (Input.GetKeyDown(KeyCode.S)) { RotateObject(Vector3.left, 45); }
            if (Input.GetKeyDown(KeyCode.D)) { RotateObject(Vector3.forward, 45); }
            if (Input.GetKeyDown(KeyCode.A)) { RotateObject(Vector3.back, 45); }
            if (Input.GetKeyDown(KeyCode.Q)) { RotateObject(Vector3.up, 45); }
            if (Input.GetKeyDown(KeyCode.E)) { RotateObject(Vector3.down, 45); }

            // Scale object when key is pressed
            if (Input.GetKeyDown(KeyCode.UpArrow)) { ScaleObject(new Vector3(0.1f, 0.1f, 0.1f)); }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { ScaleObject(new Vector3(-0.1f, -0.1f, -0.1f)); }

            if (Input.GetKeyDown(KeyCode.X)) { Destroy(newObject); }

            // Keep object on mouse pointer until it is placed.
            if (Input.GetMouseButtonDown(0))
            {
                newObject = null;
            }
        }

    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, rayRange, layerMask))
        {
            position = hit.point;
        }

        if (objectClicked)
        {
            if (Physics.Raycast(ray, out hit, rayRange, layerMaskObject))
            {
                newObject = hit.collider.gameObject;
                objectClicked = false;
            }
        }
        
    }

    // Creates an object from a predifiend array of objects.
    public void AddObject(int index)
    {
        newObject = Instantiate(objects[index], position, transform.rotation);
    }

    public void RotateObject(Vector3 vector, int degree)
    {
        newObject.transform.Rotate(vector, degree);
    }

    public void ScaleObject(Vector3 scale)
    {
        // Does not allow the object to be scaled below 0.1
        if(newObject.transform.localScale.x <= 0.1f && scale.x < 0)
        {
            return;
        }
        newObject.transform.localScale += scale;
    }
}
