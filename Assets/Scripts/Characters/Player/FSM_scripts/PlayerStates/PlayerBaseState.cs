using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState (PlayerControlsFSM Player);

    public abstract void Update (PlayerControlsFSM Player);

    public abstract void OnCollisionEnter (PlayerControlsFSM Player);
}
