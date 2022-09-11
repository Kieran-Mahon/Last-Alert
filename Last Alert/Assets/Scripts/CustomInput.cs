using UnityEngine;

//Custom input class which allows multiple keys to be checked
public static class CustomInput {
    
    public static bool GetKey(KeyCode[] keys) {
        //Make sure array is not null
        if (keys == null) {
            return false;
        }
        //Check if any key is currently pressed
        bool anyPressed = false;
        foreach (KeyCode key in keys) {
            if (Input.GetKey(key) == true) {
                anyPressed = true;
            }
        }
        //Return value
        return anyPressed;
    }

    public static bool GetKeyDown(KeyCode[] keys) {
        //Make sure array is not null
        if (keys == null) {
            return false;
        }
        //Check if any key was just pressed down
        bool anyPressed = false;
        foreach (KeyCode key in keys) {
            if (Input.GetKeyDown(key) == true) {
                anyPressed = true;
            }
        }
        //Return value
        return anyPressed;
    }

    public static bool GetKeyUp(KeyCode[] keys) {
        //Make sure array is not null
        if (keys == null) {
            return false;
        }
        //Check if any key was just let go
        bool anyPressed = false;
        foreach (KeyCode key in keys) {
            if (Input.GetKeyUp(key) == true) {
                anyPressed = true;
            }
        }
        //Return value
        return anyPressed;
    }
}