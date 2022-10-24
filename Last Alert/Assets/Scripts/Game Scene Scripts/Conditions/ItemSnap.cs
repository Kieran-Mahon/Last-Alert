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
            snapToCenter(other.gameObject);
        }
    }

    public void snapToCenter(GameObject snapObject)
    {
        if(snapObject == null)
        {
            return;
        }
        
        //Stop physics
        Rigidbody rigidbody = snapObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }

        // Change position and rotation
        snapObject.transform.position = transform.position;
        snapObject.transform.rotation = transform.rotation;
    }
}