using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SnapTest {
    Vector3 areaPos = new Vector3(10, 10, 10);
    Quaternion areaRot = new Quaternion(10, 20, 0, 0);

    [UnityTest]
    public IEnumerator PosTest() {
        ItemSnap itemSnap = new GameObject().AddComponent<ItemSnap>();

        GameObject testObject = new GameObject();

        itemSnap.snapToCenter(testObject/*, areaPos, areaRot*/);
        
        Assert.IsTrue(areaPos == testObject.transform.position);

        yield return null;
    }

    [UnityTest]
    public IEnumerator RotTest() {
        ItemSnap itemSnap = new GameObject().AddComponent<ItemSnap>();
        Quaternion areaRot = new Quaternion(10, 20, 0, 0);

        GameObject testObject = new GameObject();

        itemSnap.snapToCenter(testObject/*, areaPos, areaRot*/);

        Assert.IsTrue(new Quaternion(10, 20, 0, 0) == testObject.transform.rotation);

        yield return null;
    }

    [UnityTest]
    public IEnumerator NullTest()
    {
        ItemSnap itemSnap = new GameObject().AddComponent<ItemSnap>();
        Quaternion areaRot = new Quaternion(10, 20, 0, 0);

        GameObject testObject = null;

        itemSnap.snapToCenter(testObject/*, areaPos, areaRot*/);

        Assert.IsNull(testObject);

        yield return null;
    }
}