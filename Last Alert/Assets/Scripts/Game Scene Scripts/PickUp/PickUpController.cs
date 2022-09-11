using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    [Header("Pick Up Information")]
    public float pickUpDistance = 5;
    public float rotateSpeed = 25;

    [Header("References")]
    public GameObject itemHolderRef;
    public GameObject cameraRef;

    private bool holdingItem = false;
    private PickUp itemRef;

    public void TryMoveItem() {
        //Check if no items are held
        if (holdingItem == false) {
            //Check if the players wants to pick up an item
            PickUpItem();
        } else {
            //Move item
            MoveItem();
            //Check if the player wants to drop the item
            PutDownItem();
        }
    }

    private void PickUpItem() {
        //Check if key is pressed
        if (Input.GetKeyDown(KeyboardController.itemPickUpKey)) {
            //See if there is an item in front of the player
            if (Physics.Raycast(cameraRef.transform.position, cameraRef.transform.TransformDirection(Vector3.forward), out RaycastHit hit, pickUpDistance)) {
                //Check if the item has the pick up tag
                PickUp tempPickUp = hit.collider.GetComponent<PickUp>();
                if (tempPickUp != null) {
                    holdingItem = true;
                    itemRef = tempPickUp;
                    itemRef.held = true;
                    //Set the items parent to the holder object
                    itemRef.transform.parent = itemHolderRef.transform;
                    //Disable the physics on the item if any
                    Rigidbody rigidbody = itemRef.rigidbodyRef;
                    if (rigidbody != null) {
                        rigidbody.isKinematic = true;
                    }
                }
            }
        }
    }

    //Code which is ran when the item is being moved
    private void MoveItem() {
        KeepLevel();
        RotateItem();
    }

    //Keep item level
    private void KeepLevel() {
        itemRef.transform.eulerAngles = new Vector3(0, itemRef.transform.eulerAngles.y, 0);
    }

    //Rotate the item
    private void RotateItem() {
        float rotateAmount = 0;
        //Rotate the item left
        if (Input.GetKey(KeyboardController.itemRotateLeftKey)) {
            rotateAmount += rotateSpeed;
        }
        //Rotate the item right
        if (Input.GetKey(KeyboardController.itemRotateRightKey)) {
            rotateAmount -= rotateSpeed;
        }
        //Apply new rotation
        itemRef.transform.Rotate(new Vector3(0, rotateAmount * Time.deltaTime, 0));
    }

    //Drop the item
    private void PutDownItem() {
        //Check if key is pressed
        if (Input.GetKeyDown(KeyboardController.itemPickUpKey)) {
            ReleaseItem();
            holdingItem = false;
        }
    }

    //Disconnect the item from the player
    private void ReleaseItem() {
        //Release item from holder
        itemRef.transform.parent = null;
        //Enable the physics on the item if any
        Rigidbody rigidbody = itemRef.rigidbodyRef;
        if (rigidbody != null) {
            rigidbody.isKinematic = false;
        }
        itemRef.held = false;
    }

    public void DropItem(bool dropAtStart) {
        //Check if holding an item
        if (holdingItem == true) {
            holdingItem = false;
            //Drop at start location
            if (dropAtStart == true) {
                //Release item from holder
                itemRef.transform.parent = null;
                //Set to start location
                itemRef.ResetPickUp();
                //Update held reference
                itemRef.held = false;
            } else { //Drop at current location
                ReleaseItem();
            }
        }
    }
}