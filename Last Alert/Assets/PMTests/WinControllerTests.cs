using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WinControllerTests {
    
    private GameObject MakeGO() {
        return new GameObject();
    }

    [UnityTest]
    public IEnumerator NoConditions() {
        //Should return true when no conditions are added

        WinController winController = MakeGO().AddComponent<WinController>();
        winController.conditions = new Condition[0];

        Assert.AreEqual(true, winController.CheckForWin());
        yield return null;
    }

    [UnityTest]
    public IEnumerator OneTrueOneFalse() {
        //Should return false as only one is true

        WinController winController = MakeGO().AddComponent<WinController>();
        winController.conditions = new Condition[2];
        winController.conditions[0] = MakeGO().AddComponent<PlayerInAreaCondition>();
        winController.conditions[1] = MakeGO().AddComponent<PlayerInAreaCondition>();

        winController.conditions[0].SetCompleted(true);
        winController.conditions[1].SetCompleted(false);

        Assert.AreEqual(false, winController.CheckForWin());
        yield return null;
    }

    [UnityTest]
    public IEnumerator TwoTrue() {
        //Should return true as both are true

        WinController winController = MakeGO().AddComponent<WinController>();
        winController.conditions = new Condition[2];
        winController.conditions[0] = MakeGO().AddComponent<PlayerInAreaCondition>();
        winController.conditions[1] = MakeGO().AddComponent<PlayerInAreaCondition>();

        winController.conditions[0].SetCompleted(true);
        winController.conditions[1].SetCompleted(true);

        Assert.AreEqual(true, winController.CheckForWin());
        yield return null;
    }

    //[UnityTest]
    //public IEnumerator TwoFalse() {
    //    //Should return false as both are false

    //    WinController winController = MakeGO().AddComponent<WinController>();
    //    winController.conditions = new Condition[2];
    //    winController.conditions[0] = MakeGO().AddComponent<PlayerInAreaCondition>();
    //    winController.conditions[1] = MakeGO().AddComponent<PlayerInAreaCondition>();

    //    winController.conditions[0].SetCompleted(false);
    //    winController.conditions[1].SetCompleted(false);

    //    Assert.AreEqual(false, winController.CheckForWin());
    //    yield return null;
    //}


    //FAKE FAIL
    [UnityTest]
    public IEnumerator TwoFalse() {
        //Should return false as both are false

        WinController winController = MakeGO().AddComponent<WinController>();
        winController.conditions = new Condition[2];
        winController.conditions[0] = MakeGO().AddComponent<PlayerInAreaCondition>();
        winController.conditions[1] = MakeGO().AddComponent<PlayerInAreaCondition>();

        winController.conditions[0].SetCompleted(false);
        winController.conditions[1].SetCompleted(false);

        Assert.AreEqual(true, winController.CheckForWin());
        yield return null;
    }
}