using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCondition : Condition {

    //Result reference
    public Result result;

    void Update() {
        completed = result.completed;
    }

    public override void ResetCondition() {
        result.ResetResult();
    }
}