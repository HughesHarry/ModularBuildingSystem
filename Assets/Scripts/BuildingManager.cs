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

        if (newObject != null)
        {
            newObject.transform.position = position;
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
    }

    // Creates an object from a predifiend array of objects.
    public void AddObject(int index)
    {
        newObject = Instantiate(objects[index], position, transform.rotation);
    }
}
