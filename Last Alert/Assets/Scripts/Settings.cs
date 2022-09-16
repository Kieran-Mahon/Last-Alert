using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public GameObject SceneScript; //reference to current scene controller

    public Toggle mouseXInvert;
    public Toggle mouseYInvert;

    public GameObject currentKey = null;
    public KeyCode[] mouseKeys = { KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.Mouse2 };

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
        mouseXInvert.onValueChanged.AddListener(delegate {InvertMouseX(mouseXInvert);});
        mouseYInvert.onValueChanged.AddListener(delegate {InvertMouseY(mouseYInvert);});
        UpdateAllButtonText();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //leave settings
    // public void BackButton(){
    //     if(SceneScript.name == "StartSceneController"){
    //         StartSceneController.ChangeStartState(StartSceneController.StartState.HOMEMENU);
    //     }else if(SceneScript.name == "GameController"){
    //         GameController.ChangeGameState(GameController.GameState.PAUSEMENU);
    //     }else{
    //         Debug.Log("failed to access scene script");
    //     }
    // }

    //mouse inversion settings
    public void InvertMouseX(Toggle selectedToggle){
       if(selectedToggle.isOn){
            PlayerController.mouseXInverted = true;
        }else{
            PlayerController.mouseXInverted = false;
        }

        Debug.Log(PlayerController.mouseXInverted);
    }

    public void InvertMouseY(Toggle selectedToggle){
        if(selectedToggle.isOn){
            PlayerController.mouseYInverted = true;
        }else{
            PlayerController.mouseYInverted = false;
        }
    }

    //keybind settings
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
            if(e.isKey || e.isMouse){
                UpdateKeyBind(e);
                currentKey = null;
            }
        }
    }

    public void UpdateKeyBind(Event e){
        KeyCode newKey = KeyCode.Mouse3;

        //mouse click
        if (e.isMouse){
            if (e.type == EventType.MouseDown){
                for (int i = 0; i < mouseKeys.Length; ++i){
                    if (Input.GetKeyDown(mouseKeys[i])){
                        newKey = mouseKeys[i];
                        break;
                    }
                }
            }
        }
        //key press
        else if (e.isKey){
            newKey = e.keyCode;
        }

        //assign new keybind
        switch(currentKey.name){
            case "btnPause":
                ChangeKeyBind(KeyboardController.Action.PAUSE, newKey);
                UpdateButtonText(pauseText, KeyboardController.pauseKey[0].ToString());
                break;
            case "btnJump":
                ChangeKeyBind(KeyboardController.Action.JUMP, newKey);
                UpdateButtonText(jumpText, KeyboardController.jumpKey[0].ToString());
                break;
            case "btnSprint":
                ChangeKeyBind(KeyboardController.Action.RUN, newKey);
                UpdateButtonText(sprintText, KeyboardController.runKey[0].ToString());
                break;
            case "btnCrouch":
                ChangeKeyBind(KeyboardController.Action.CROUCH, newKey);
                UpdateButtonText(crouchText, KeyboardController.crouchKey[0].ToString());
                break;
            case "btnPickUpDrop":
                ChangeKeyBind(KeyboardController.Action.ITEMPICKUP, newKey);
                UpdateButtonText(pickUpDropText, KeyboardController.itemPickUpKey[0].ToString());
                break;
            case "btnRotateLeft":
                ChangeKeyBind(KeyboardController.Action.ITEMROTATELEFT, newKey);
                UpdateButtonText(rotateLeftText, KeyboardController.itemRotateLeftKey[0].ToString());
                break;
            case "btnRotateRight":
                ChangeKeyBind(KeyboardController.Action.ITEMROTATERIGHT, newKey);
                UpdateButtonText(rotateRightText, KeyboardController.itemRotateRightKey[0].ToString());
                break;
            default:
                break;
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
