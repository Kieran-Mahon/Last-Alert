using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneController : MonoBehaviour {
    //Game state
    public StartState startState;

    //Home reference
    public GameObject homeMenu;

    //Settings reference
    public GameObject settingsUI;
    public Settings settingRef;

    //References
    //UI controller reference
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
            homeMenu.SetActive(true);
            settingsUI.SetActive(false);
            settingRef.enabled = false;

        } else if (newStartState == StartState.SETTINGMENU) {
            MouseController.UnlockMouse();
            settingsUI.SetActive(true);
            settingRef.enabled = true;
            homeMenu.SetActive(false);

        } else if (newStartState == StartState.CUTSCENE) {
            MouseController.UnlockMouse();
        }
        //Change state
        startState = newStartState;
    }

    //New Game Button
    public void NewGame() {
        SceneController.SwitchToGameScene();
    }

    //Continue Button
    public void ContinueGame() {
        //continues game from last checkpoint save (if available)
        print("Continue");
    }

    //Settings Button
    public void OpenSettings() {
        ChangeStartState(StartState.SETTINGMENU);
    }

    //temporary button to return to home menu for testing
    public void CloseSettings() {
        ChangeStartState(StartState.HOMEMENU);
    }

    //Quit Button
    public void Quit() {
        Application.Quit();
        print("Quit");
    }
}

//Start scene states
public enum StartState {
    HOMEMENU,
    SETTINGMENU,
    CUTSCENE
}