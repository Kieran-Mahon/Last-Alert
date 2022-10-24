using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpacPhysicsTests {

    // Testing that the players speed in space is calculated
    [UnityTest]
    public void SpaceLess0Case() {
        float velocity = -5.0f;
        velocity = PlayerController.CalculateVelocity(velocity, 0.1f, 0.05f, 15.0f);

        Assert.IsTrue(velocity >= 0);
        Assert.IsTrue(velocity <= 15.0f);
    }

    [UnityTest]
    public void SpaceBetweenCase() {
        float velocity = 0.0f;
        velocity = PlayerController.CalculateVelocity(velocity, 0.1f, 0.05f, 15.0f);
Debug.Log("HI");
        Assert.IsTrue(velocity >= 0);
        Assert.IsTrue(velocity <= 15.0f);
    }

    [UnityTest]
    public void SpaceGreaterThenCase() {
        float velocity = 20.0f;
        velocity = PlayerController.CalculateVelocity(velocity, 0.1f, 0.05f, 15.0f);

        Assert.IsTrue(velocity >= 0);
        Assert.IsTrue(velocity <= 15.0f);
    }
}