using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour {
    //Game state
    public StartState startState;

    //References
    //UI controller reference
    //Setting reference
    //etc. etc..


    // Start is called before the first frame update
    void Start() {
        ChangeStartState(StartState.HOMEMENU);
    }

    // Update is called once per frame
    void Update() {
        if (startState == StartState.HOMEMENU) {

            //Example code of scene switching to make sure it works
            if (Input.GetKeyDown(KeyCode.J)) {
                SceneController.SwitchToGameScene();
            }

        } else if (startState == StartState.SETTINGMENU) {

        } else if (startState == StartState.CUTSCENE) {

        }
    }

    //Actions which need to be done on the change state call
    public void ChangeStartState(StartState newStartState) {
        if (newStartState == StartState.HOMEMENU) {
            MouseController.UnlockMouse();
        } else if (newStartState == StartState.SETTINGMENU) {
            MouseController.UnlockMouse();
        } else if (newStartState == StartState.CUTSCENE) {
            MouseController.UnlockMouse();
        }
        //Change state
        startState = newStartState;
    }
    
    public void TestButton()
    {
        Debug.Log("Button Clicked");
    }
}

//Start scene states
public enum StartState {
    HOMEMENU,
    SETTINGMENU,
    CUTSCENE
}