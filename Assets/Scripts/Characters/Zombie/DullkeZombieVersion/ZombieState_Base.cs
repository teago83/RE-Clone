
public abstract class ZombieState_Base
{
    public abstract void OnEnterState(ZombieAIFSM zScript);
    public abstract void Update(ZombieAIFSM zScript);
    public abstract void OnCollisionEnter(ZombieAIFSM zScript);
}
