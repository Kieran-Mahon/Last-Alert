using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel : Result {

    //The state of the panel
    public State panelState = State.NOTCOMPLETED;

    [Header("Panel UI")]
    public GameObject hintUI;
    public GameObject uncompletedUI;
    public GameObject completedUI;
    
    //Used with UI
    public void changeState(State newState) {
        panelState = newState;
    }

    //The state the panel is in
    public enum State {
        HINT,
        NOTCOMPLETED,
        COMPLETED
    }
}