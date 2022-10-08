using UnityEngine;

public abstract class Result : MonoBehaviour {
    public bool completed = false;

    public Condition conditions;

    public abstract void ResetResult();
}