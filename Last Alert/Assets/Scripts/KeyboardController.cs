using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyboardController {
    //Movement keys
    public static KeyCode[] runKey = { KeyCode.LeftShift };
    public static KeyCode[] jumpKey = { KeyCode.Space };
    public static KeyCode[] crouchKey = { KeyCode.LeftControl };
    //Pick up key
    public static KeyCode[] itemPickUpKey = { KeyCode.Mouse0 };
    public static KeyCode[] itemRotateLeftKey = { KeyCode.Q };
    public static KeyCode[] itemRotateRightKey = { KeyCode.E };
    //Pause key
    public static KeyCode[] pauseKey = { KeyCode.Escape };

    //Add a key to an action
    public static void AddKey(Action action, KeyCode newKeyCode) {
        //Call the AddToArray function depending on what action was called
        switch (action) {
            case Action.RUN:
                runKey = AddToArray(runKey, newKeyCode);
                break;
            case Action.JUMP:
                jumpKey = AddToArray(jumpKey, newKeyCode);
                break;
            case Action.CROUCH:
                crouchKey = AddToArray(crouchKey, newKeyCode);
                break;
            case Action.ITEMPICKUP:
                itemPickUpKey = AddToArray(itemPickUpKey, newKeyCode);
                break;
            case Action.ITEMROTATELEFT:
                itemRotateLeftKey = AddToArray(itemRotateLeftKey, newKeyCode);
                break;
            case Action.ITEMROTATERIGHT:
                itemRotateRightKey = AddToArray(itemRotateRightKey, newKeyCode);
                break;
            case Action.PAUSE:
                pauseKey = AddToArray(pauseKey, newKeyCode);
                break;
            default:
                break;
        }
    }

    private static KeyCode[] AddToArray(KeyCode[] array, KeyCode key) {
        //Check if keycode is not already in the array
        if (CheckForKeyCode(array, key) == -1) {

            //Make new array 1 length longer
            KeyCode[] tempArray = new KeyCode[array.Length + 1];

            //Copy values from old array over
            for (int i = 0; i < array.Length; i++) {
                tempArray[i] = array[i];
            }

            //Add new key to array
            tempArray[array.Length] = key;

            //Return array
            return tempArray;
        } else {
            //Already in the array
            return array;
        }
    }

    //Remove a keycode from its action
    public static void RemoveKey(Action action, KeyCode oldKeyCode) {
        //Call the RemoveFromArray function depending on what action was called
        switch (action) {
            case Action.RUN:
                runKey = RemoveFromArray(runKey, oldKeyCode);
                break;
            case Action.JUMP:
                jumpKey = RemoveFromArray(jumpKey, oldKeyCode);
                break;
            case Action.CROUCH:
                crouchKey = RemoveFromArray(crouchKey, oldKeyCode);
                break;
            case Action.ITEMPICKUP:
                itemPickUpKey = RemoveFromArray(itemPickUpKey, oldKeyCode);
                break;
            case Action.ITEMROTATELEFT:
                itemRotateLeftKey = RemoveFromArray(itemRotateLeftKey, oldKeyCode);
                break;
            case Action.ITEMROTATERIGHT:
                itemRotateRightKey = RemoveFromArray(itemRotateRightKey, oldKeyCode);
                break;
            case Action.PAUSE:
                pauseKey = RemoveFromArray(pauseKey, oldKeyCode);
                break;
            default:
                break;
        }
    }

    private static KeyCode[] RemoveFromArray(KeyCode[] array, KeyCode key) {
        //Check if the array has the keycode
        int index = CheckForKeyCode(array, key);

        //Key not in array
        if (index == -1) {
            return array;
        }

        //Make new array 1 length less
        KeyCode[] tempArray = new KeyCode[array.Length - 1];
        //Copy values from old array over exluding the index value
        int j = 0;
        for (int i = 0; i < array.Length; i++) {
            if (i != index) {
                tempArray[j] = array[i];
                j++;
            }
        }

        //Return array
        return tempArray;
    }

    //Check for keycode in array, a value of -1 means it is not in the array
    private static int CheckForKeyCode(KeyCode[] array, KeyCode key) {
        int index = -1;
        for (int i = 0; i < array.Length; i++) {
            if (array[i] == key) {
                index = i;
            }
        }
        return index;
    }

    //Clears the key
    public static void ClearKey(Action key) {
        switch (key) {
            case Action.RUN:
                runKey = new KeyCode[] { };
                break;
            case Action.JUMP:
                jumpKey = new KeyCode[] { };
                break;
            case Action.CROUCH:
                crouchKey = new KeyCode[] { };
                break;
            case Action.ITEMPICKUP:
                itemPickUpKey = new KeyCode[] { };
                break;
            case Action.ITEMROTATELEFT:
                itemRotateLeftKey = new KeyCode[] { };
                break;
            case Action.ITEMROTATERIGHT:
                itemRotateRightKey = new KeyCode[] { };
                break;
            case Action.PAUSE:
                pauseKey = new KeyCode[] { };
                break;
            default:
                break;
        }
    }

    public static void ClearAllKeys() {
        ClearKey(Action.RUN);
        ClearKey(Action.JUMP);
        ClearKey(Action.CROUCH);
        ClearKey(Action.RUN);
        ClearKey(Action.RUN);
        ClearKey(Action.RUN);
        ClearKey(Action.PAUSE);
    }

    //Returns true if the key is in use
    public static bool CheckForKeyInUse(KeyCode key) {
        bool used = false;
        if (CheckForKeyCode(runKey, key) != -1) {
            used = true;
        }
        if (CheckForKeyCode(jumpKey, key) != -1) {
            used = true;
        }
        if (CheckForKeyCode(crouchKey, key) != -1) {
            used = true;
        }
        if (CheckForKeyCode(itemPickUpKey, key) != -1) {
            used = true;
        }
        if (CheckForKeyCode(itemRotateLeftKey, key) != -1) {
            used = true;
        }
        if (CheckForKeyCode(itemRotateRightKey, key) != -1) {
            used = true;
        }
        if (CheckForKeyCode(pauseKey, key) != -1) {
            used = true;
        }
        return used;
    }

    public enum Action {
        RUN,
        JUMP,
        CROUCH,
        ITEMPICKUP,
        ITEMROTATELEFT,
        ITEMROTATERIGHT,
        PAUSE
    }
}