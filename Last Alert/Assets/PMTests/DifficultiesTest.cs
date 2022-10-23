using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DifficultiesTest {

    StartSceneController startSceneController;

    [SetUp]
    public void Setup() {
        startSceneController = new GameObject().AddComponent<StartSceneController>();
    }

    [UnityTest]
    public IEnumerator EasyTest() {
        //faux Easy button
        GameObject btnEasy = new GameObject("btnEasy");

        //Call function
        startSceneController.SetDifficulty(btnEasy);

        //Check
        float result = GameTimer.GetTimeLeft();
        float expectedResult = 30; //temp Easy time
        Assert.AreEqual(expectedResult, result);

        yield return null;
    }

    [UnityTest]
    public IEnumerator NormalTest() {
        //faux Normal button
        GameObject btnNormal = new GameObject("btnNormal");

        //Call function
        startSceneController.SetDifficulty(btnNormal);

        //Check
        float result = GameTimer.GetTimeLeft();
        float expectedResult = 20; //temp Normal time
        Assert.AreEqual(expectedResult, result);

        yield return null;
    }

    [UnityTest]
    public IEnumerator HardTest() {
        //faux Hard button
        GameObject btnHard = new GameObject("btnHard");

        //Call function
        startSceneController.SetDifficulty(btnHard);

        //Check
        float result = GameTimer.GetTimeLeft();
        float expectedResult = 10; //temp Hard time
        Assert.AreEqual(expectedResult, result);

        yield return null;
    }
}
