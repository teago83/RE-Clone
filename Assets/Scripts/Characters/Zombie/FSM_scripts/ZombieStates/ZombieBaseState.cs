using UnityEngine;

public abstract class ZombieBaseState
{
    public abstract void EnterState (ZombieBehaviourFSM Zombie);

    public abstract void Update (ZombieBehaviourFSM Zombie);

    public abstract void OnCollisionEnter (ZombieBehaviourFSM Zombie);
}
