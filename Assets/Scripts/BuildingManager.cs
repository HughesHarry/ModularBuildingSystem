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
        if(newObject != null)
        {
            newObject.transform.position = position;
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

    public void SelectObject(int index)
    {
        newObject = Instantiate(objects[index], position, transform.rotation);
    }
}
