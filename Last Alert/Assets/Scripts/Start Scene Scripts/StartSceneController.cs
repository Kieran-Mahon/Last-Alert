using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour {
    //Start state
    public StartState startState;

    //Home reference
    public GameObject homeMenu;

    //Settings reference
    public GameObject settingsUI;
    public Settings settingRef;

    //References
    //UI controller reference
    //etc. etc..
    public Button continueBtn;

    // Start is called before the first frame update
    void Start() {
        ChangeStartState(StartState.HOMEMENU);

        print("data loading...");
        PlayerData data = SaveSystem.load();
        if(data != null){
            continueBtn.interactable = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (startState == StartState.HOMEMENU) {

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
        SaveSystem.save(null);
        AudioManager.instance.Pause("homeTheme");
        AudioManager.instance.Play("gameBackground");
        SceneController.SwitchToGameScene();
        //SceneController.SwitchToTutorialScene();

    }

    //Continue Button
    public void ContinueGame() {
        //continues game from last checkpoint save (if available)
        //SceneController.SwitchToTutorialScene();
        AudioManager.instance.Pause("homeTheme");
        AudioManager.instance.Play("gameBackground");
        SceneController.SwitchToGameScene();
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