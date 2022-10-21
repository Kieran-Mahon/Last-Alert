using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchMovement : MonoBehaviour {
    public UnityEvent entered, exited;

    void OnTriggerEnter(Collider other) {
        //check if player has entered
        if (other.name == "Player") {
            PlayerController.inSpace = true;
        }
    }

    void OnTriggerExit(Collider other) {
        //checks if player has exited
        if (other.name == "Player") {

        }
    }
}