using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//data structure to hold data
[System.Serializable]
public class PlayerData
{
    public float[] position = new float[] { 0.0f, 0.0f, 0.0f };
    public float timer = 100.0f;

    //KeyCodes
    public int runKey = (int)KeyCode.LeftShift;
    public int jumpKey = (int)KeyCode.Space;
    public int crouchKey = (int)KeyCode.LeftControl;
    //Pick up key
    public int itemPickUpKey = (int)KeyCode.Mouse0;
    public int itemRotateLeftKey = (int)KeyCode.Q;
    public int itemRotateRightKey = (int)KeyCode.E;
    //Pause key
    public int pauseKey = (int)KeyCode.Escape;

    public PlayerData()
    {

    }

    //constructor
    public PlayerData(Transform player, float timer)
    {
        this.position = new float[3];

        if (player != null)
        {
            this.position[0] = player.position.x;
            this.position[1] = player.position.y;
            this.position[2] = player.position.z;

        }
        else
        {
            this.position[0] = 0.0f;
            this.position[1] = 0.0f;
            this.position[2] = 0.0f;
        }

        this.timer = timer;

        this.runKey = (int)KeyboardController.runKey;
        this.jumpKey = (int)KeyboardController.jumpKey;
        this.crouchKey = (int)KeyboardController.crouchKey;
        this.itemPickUpKey = (int)KeyboardController.itemPickUpKey;
        this.itemRotateLeftKey = (int)KeyboardController.itemRotateLeftKey;
        this.itemRotateRightKey = (int)KeyboardController.itemRotateRightKey;
        this.pauseKey = (int)KeyboardController.pauseKey;

    }

}
