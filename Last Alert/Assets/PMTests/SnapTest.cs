using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SnapTest
{
    [UnityTest]
    public IEnumerator PosTest()
    {

        private Vector3 areaPos = new Vector3(10, 10, 10);
        //private Vector3 snapPos;
        //private Quaternion snapRot;
        
        GameObject testObject = new GameObject();



        Assert.AreSame(areaPos, testObject.transform.position);
        
        yield return null;
    }
}
