using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//data structure to hold data
[System.Serializable]
public class PlayerData {
    public float[] position = new float[] { 0.0f, 0.0f, 0.0f };
    public float timer = 100.0f;

    public float volume = 0.5f;
    public float sensitivity = 2.0f;

    //KeyCodes
    public string runKey = KeyCode.LeftShift.ToString();
    public string jumpKey = KeyCode.Space.ToString();
    public string crouchKey = KeyCode.LeftControl.ToString();
    //Pick up key
    public string itemPickUpKey = KeyCode.Mouse0.ToString();
    public string itemRotateLeftKey = KeyCode.Q.ToString();
    public string itemRotateRightKey = KeyCode.E.ToString();
    //Pause key
    public string pauseKey = (int)KeyCode.Escape;

    public PlayerData() {

    }

    //constructor
    public PlayerData(Transform player, float timer) {
        this.position = new float[3];

        if (player != null) {
            this.position[0] = player.position.x;
            this.position[1] = player.position.y;
            this.position[2] = player.position.z;

        } else {
            this.position[0] = 0.0f;
            this.position[1] = 0.0f;
            this.position[2] = 0.0f;
        }

        this.timer = timer;

        this.volume = AudioManager.volumeSetting;
        this.sensitivity = PlayerController.mouseXSensitivity;

        this.runKey = KeyboardController.runKey.ToString();
        this.jumpKey = KeyboardController.jumpKey.ToString();
        this.crouchKey = KeyboardController.crouchKey.ToString();
        this.itemPickUpKey = KeyboardController.itemPickUpKey.ToString();
        this.itemRotateLeftKey = KeyboardController.itemRotateLeftKey.ToString();
        this.itemRotateRightKey = KeyboardController.itemRotateRightKey.ToString();
        this.pauseKey = KeyboardController.pauseKey.ToString();

    }

}
