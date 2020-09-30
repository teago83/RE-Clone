using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour_FSM : MonoBehaviour
{
    private ZombieBaseState CurrentZombieState;

    public readonly ZombieIdleState IdleState = new ZombieIdleState();
    public readonly ZombiePatrolState PatrolState = new ZombiePatrolState();
    public readonly ZombieCombatState CombatState = new ZombieCombatState();

    public readonly int WaitingTime = 25;
    public readonly float Speed = 2.5f;
    public readonly float TurnSpeed = 180;

    public Transform PathHolder;

    private Rigidbody Rigidbody;

    public Rigidbody Rb
    {
        get { return Rigidbody; }
    }

    private void Start()
    {
        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentZombieState.Update(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CurrentZombieState.OnCollisionEnter(this);
    }

    public void TransitionToState(ZombieBaseState State)
    {
        CurrentZombieState = State;
        CurrentZombieState.EnterState(this);
    }

    void OnDrawGizmos()
    {
        // "StartPosition" is a Vector3 that takes the first child of the PathHolder's position (x, y, z).
        Vector3 StartPosition = PathHolder.GetChild(0).position;
        Vector3 PreviousPosition = StartPosition;

        foreach (Transform waypoint in PathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, 1f);
            Gizmos.DrawLine(PreviousPosition, waypoint.position);
            PreviousPosition = waypoint.position;
        }
        // This makes the last position connect to the first one.
        Gizmos.DrawLine(PreviousPosition, StartPosition);
    }

    IEnumerator TurnToFace(Vector3 LookTarget)
    {
        Vector3 DirToLookTarget = (LookTarget - transform.position).normalized;
        float TargetAngle = 90 - Mathf.Atan2(DirToLookTarget.z, DirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, TargetAngle)) > .05)
        {
            float Angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, TargetAngle, TurnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * Angle;
            yield return null;
        }
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];
        int TargetWaypointIndex = 1;
        Vector3 TargetWaypoint = waypoints[TargetWaypointIndex];
        transform.LookAt(TargetWaypoint);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetWaypoint, Speed * Time.deltaTime);
            if (transform.position == TargetWaypoint)
            {
                TargetWaypointIndex = (TargetWaypointIndex + 1) % waypoints.Length;
                TargetWaypoint = waypoints[TargetWaypointIndex];
                yield return new WaitForSeconds(WaitingTime);
                yield return StartCoroutine(TurnToFace(TargetWaypoint));
                // This whole if statement means: if the enemy reaches one of its waypoints, its current target waypoint 
                // will be updated to the next one and the enemy will wait for some seconds before moving on.
            }
            yield return null;
        }
    }

}
