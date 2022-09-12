using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public GameObject currentKey = null;

    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI forwardText;
    public TextMeshProUGUI backwardText;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI jumpText;
    public TextMeshProUGUI sprintText;
    public TextMeshProUGUI crouchText;
    public TextMeshProUGUI pickUpDropText;
    public TextMeshProUGUI rotateLeftText;
    public TextMeshProUGUI rotateRightText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAllButtonText();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestoreDefaultKeyBinds(){
        ChangeKeyBind(KeyboardController.Action.PAUSE, KeyCode.Escape);
        ChangeKeyBind(KeyboardController.Action.JUMP, KeyCode.Space);
        ChangeKeyBind(KeyboardController.Action.RUN, KeyCode.LeftShift);
        ChangeKeyBind(KeyboardController.Action.CROUCH, KeyCode.LeftControl);
        ChangeKeyBind(KeyboardController.Action.ITEMPICKUP, KeyCode.Mouse0);
        ChangeKeyBind(KeyboardController.Action.ITEMROTATELEFT, KeyCode.Q);
        ChangeKeyBind(KeyboardController.Action.ITEMROTATERIGHT, KeyCode.E);

        UpdateAllButtonText();
    }

    public void UpdateButtonText(TextMeshProUGUI buttonText, string keyBind){
        buttonText.text = keyBind;
    }

    public void UpdateAllButtonText(){
        //unchangeable keybinds
        forwardText.text = "W";
        backwardText.text = "S";
        leftText.text = "A";
        rightText.text = "D";

        //changeable keybinds
        UpdateButtonText(pauseText, KeyboardController.pauseKey[0].ToString());
        UpdateButtonText(jumpText, KeyboardController.jumpKey[0].ToString());
        UpdateButtonText(sprintText, KeyboardController.runKey[0].ToString());
        UpdateButtonText(crouchText, KeyboardController.crouchKey[0].ToString());
        UpdateButtonText(pickUpDropText, KeyboardController.itemPickUpKey[0].ToString());
        UpdateButtonText(rotateLeftText, KeyboardController.itemRotateLeftKey[0].ToString());
        UpdateButtonText(rotateRightText, KeyboardController.itemRotateRightKey[0].ToString());
    }

    void OnGUI()
    {
        if(currentKey != null){
            Event e = Event.current;
            if(e.isKey){
                switch(currentKey.name){
                    case "btnPause":
                        ChangeKeyBind(KeyboardController.Action.PAUSE, e.keyCode);
                        UpdateButtonText(pauseText, KeyboardController.pauseKey[0].ToString());
                        break;
                    case "btnJump":
                        ChangeKeyBind(KeyboardController.Action.JUMP, e.keyCode);
                        UpdateButtonText(jumpText, KeyboardController.jumpKey[0].ToString());
                        break;
                    case "btnSprint":
                        ChangeKeyBind(KeyboardController.Action.RUN, e.keyCode);
                        UpdateButtonText(sprintText, KeyboardController.runKey[0].ToString());
                        break;
                    case "btnCrouch":
                        ChangeKeyBind(KeyboardController.Action.CROUCH, e.keyCode);
                        UpdateButtonText(crouchText, KeyboardController.crouchKey[0].ToString());
                        break;
                    case "btnPickUpDrop":
                        ChangeKeyBind(KeyboardController.Action.ITEMPICKUP, e.keyCode);
                        UpdateButtonText(pickUpDropText, KeyboardController.itemPickUpKey[0].ToString());
                        break;
                    case "btnRotateLeft":
                        ChangeKeyBind(KeyboardController.Action.ITEMROTATELEFT, e.keyCode);
                        UpdateButtonText(rotateLeftText, KeyboardController.itemRotateLeftKey[0].ToString());
                        break;
                    case "btnRotateRight":
                        ChangeKeyBind(KeyboardController.Action.ITEMROTATERIGHT, e.keyCode);
                        UpdateButtonText(rotateRightText, KeyboardController.itemRotateRightKey[0].ToString());
                        break;
                    default:
                        break;
                }
                currentKey = null;
            }
        }
    }

    public void ChangeKeyBind(KeyboardController.Action control, KeyCode newKey){
        KeyboardController.ClearKey(control);
        KeyboardController.AddKey(control, newKey);
    }

    public void CurrentKey(GameObject clicked){
        currentKey = clicked;
    }
}
