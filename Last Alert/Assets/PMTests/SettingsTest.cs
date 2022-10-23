using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SettingsTest {

    [UnityTest]
    public IEnumerator ChangeKeyBind() {
        //Set up
        Settings settings = new GameObject().AddComponent<Settings>();
        settings.CurrentKey(new GameObject("Crouch"));
        Event customEvent = new Event();

        //Call function
        settings.UpdateKeyBind(customEvent);
        
        //Check
        Assert.AreEqual("a", KeyboardController.crouchKey);
        yield return null;
    }
}