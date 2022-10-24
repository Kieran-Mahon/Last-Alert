using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSnap : MonoBehaviour
{
    public GameObject wantedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == wantedObject)
        {
            //snapToCenter(other.gameObject);
        }
    }

    public void snapToCenter(GameObject snapObject, Vector3 areaPos, Quaternion areaRot)
    {
        snapObject.transform.position = areaPos;
        snapObject.transform.rotation = areaRot;
    }
}
