using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInfo : MonoBehaviour
{

    private TMP_Text objectInfo;
    [SerializeField] private BuildingManager BuildingManager;
    // Start is called before the first frame update
    void Start()
    {
        objectInfo = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildingManager.selectedObject != null)
        {
            objectInfo.text = "Object Name: " + BuildingManager.selectedObject.name +
                "\nPosition: " + BuildingManager.selectedObject.transform.position.ToString() +
                "\nDimensions: " + BuildingManager.selectedObject.transform.localScale.ToString() +
                "\nRotation: " + BuildingManager.selectedObject.transform.rotation.eulerAngles.ToString();
        }
    }
}
