using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerFSM Player);

    public abstract void Update(PlayerFSM Player);

    public abstract void OnCollisionEnter(PlayerFSM Player);
}
