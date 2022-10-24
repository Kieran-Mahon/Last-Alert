using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpacPhysicsTests {

    // Testing that the players speed in space is calculated
    [UnityTest]
    public IEnumerator SpaceLess0Case() {
        float velocity = -5.0f;
        velocity = PlayerController.CalculateVelocity(velocity, 0.1f, 0.05f, 15.0f);

        Assert.IsTrue(velocity >= 0);
        Assert.IsTrue(velocity <= 15.0f);

        yield return null;
    }

    [UnityTest]
    public IEnumerator SpaceBetweenCase() {
        float velocity = 0.0f;
        velocity = PlayerController.CalculateVelocity(velocity, 0.1f, 0.05f, 15.0f);

        Assert.IsTrue(velocity >= 0);
        Assert.IsTrue(velocity <= 15.0f);

        yield return null;
    }

    [UnityTest]
    public IEnumerator SpaceGreaterThenCase() {
        float velocity = 20.0f;
        velocity = PlayerController.CalculateVelocity(velocity, 0.1f, 0.05f, 15.0f);

        Assert.IsTrue(velocity >= 0);
        Assert.IsTrue(velocity <= 15.0f);

        yield return null;
    }
}