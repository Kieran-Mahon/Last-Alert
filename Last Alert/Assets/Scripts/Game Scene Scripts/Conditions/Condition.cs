using UnityEngine;

public abstract class Condition : MonoBehaviour {
    public bool completed = false;

    public abstract void ResetCondition();
}