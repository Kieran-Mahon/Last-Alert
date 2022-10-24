using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SnapTest
{
    ItemSnap itemSnap;
    Vector3 areaPos = new Vector3(20, 100, 5);
    Quaternion areaRot = new Quaternion(100, 359, 50, 0);

    [UnityTest]
    public IEnumerator PosTest()
    {
        Vector3 areaPos = new Vector3(10, 10, 10);

        GameObject testObject = new GameObject();

        itemSnap.snapToCenter(testObject, areaPos, areaRot); 

        Assert.AreSame(areaPos, testObject.transform.position);

        yield return null;
    }

    public IEnumerator RotTest()
    {
        Quaternion areaRot = new Quaternion(10, 20, 0, 0);

        GameObject testObject = new GameObject();

        itemSnap.snapToCenter(testObject, areaPos, areaRot);

        Assert.AreSame(areaRot, testObject.transform.rotation);

        yield return null;
    }
}
