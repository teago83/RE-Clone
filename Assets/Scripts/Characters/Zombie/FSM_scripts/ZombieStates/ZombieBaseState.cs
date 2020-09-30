using UnityEngine;

public abstract class ZombieBaseState
{
    public abstract void EnterState (ZombieBehaviour_FSM Zombie);

    public abstract void Update (ZombieBehaviour_FSM Zombie);

    public abstract void OnCollisionEnter (ZombieBehaviour_FSM Zombie);
}
