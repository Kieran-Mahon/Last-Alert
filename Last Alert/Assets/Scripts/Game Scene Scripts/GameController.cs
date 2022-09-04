using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //Game state
    public GameState gameState;

    //References
    public PlayerController playerControllerRef;
    public PickUpController pickUpControllerRef;
    public WinController winControllerRef;
    public PickUpObjectManager pickUpObjectManagerRef; //Manages all pickup objects in the scene

    //Start is called before the first frame update
    void Start() {
        pickUpObjectManagerRef.GetAllPickUps();
        ChangeGameState(GameState.GAME);
    }

    //Update is called once per frame
    void Update() {
        if (gameState == GameState.PAUSEMENU) {
            //Unpause game
            if (Input.GetKeyDown(KeyboardController.pauseKey)) {
                UnpauseGame();
                ChangeGameState(GameState.GAME);
            }

        } else if (gameState == GameState.SETTINGMENU) {
            //Unpause game
            if (Input.GetKeyDown(KeyboardController.pauseKey)) {
                UnpauseGame();
                ChangeGameState(GameState.GAME);
            }

        } else if (gameState == GameState.CUTSCENE) {

        } else if (gameState == GameState.TUTORIAL) {
            playerControllerRef.MovePlayer();
            playerControllerRef.MoveCamera();

        } else if (gameState == GameState.GAME) {
            //Move player
            playerControllerRef.MovePlayer();
            playerControllerRef.MoveCamera();

            //Object pick up
            pickUpControllerRef.TryMoveObject();

            //Pause game
            if (Input.GetKeyDown(KeyboardController.pauseKey)) {
                PauseGame();
                ChangeGameState(GameState.PAUSEMENU);
            }

            //Check for win
            if (winControllerRef.CheckForWin()) {
                GameWon();
            }
            

            //Example of teleporting the player
            if (Input.GetKey(KeyCode.L)) {
                playerControllerRef.SetLocation(new Vector3(0, 0, 0));
                playerControllerRef.SetCameraAngle(new Vector2(0, 180));
            }
            
            //Example code of scene switching to make sure it works
            if (Input.GetKeyDown(KeyCode.J)) {
                SceneController.SwitchToStartScene();
            }

        } else if (gameState == GameState.FINISHMENU) {
            pickUpControllerRef.DropObject(true);
        }
    }

    //Actions which need to be done on the change state call
    public void ChangeGameState(GameState newGameState) {
        if (newGameState == GameState.PAUSEMENU) {
            MouseController.UnlockMouse();
        } else if (newGameState == GameState.SETTINGMENU) {
            MouseController.UnlockMouse();
        } else if (newGameState == GameState.CUTSCENE) {

        } else if (newGameState == GameState.TUTORIAL) {
            MouseController.LockMouse();
        } else if (newGameState == GameState.GAME) {
            MouseController.LockMouse();
        } else if (newGameState == GameState.FINISHMENU) {
            MouseController.UnlockMouse();
        }
        //Change state
        gameState = newGameState;
    }

    public void PauseGame() {
        pickUpObjectManagerRef.PauseAll();
    }

    public void UnpauseGame() {
        pickUpObjectManagerRef.UnpauseAll();
    }

    private void GameWon() {
        ChangeGameState(GameState.FINISHMENU);
        print("GAME WON");
    }
}

//Game scene states
public enum GameState {
    PAUSEMENU,
    SETTINGMENU,
    CUTSCENE,
    TUTORIAL,
    GAME,
    FINISHMENU
}