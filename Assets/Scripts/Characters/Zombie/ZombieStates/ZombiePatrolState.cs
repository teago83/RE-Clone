using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePatrolState : ZombieBaseState
{
    public override void EnterState(ZombieBehaviour_FSM Zombie)
    {
        
    }

    public override void OnCollisionEnter(ZombieBehaviour_FSM Zombie)
    {
        
    }

    public override void Update(ZombieBehaviour_FSM Zombie)
    {
        /*Vector3[] waypoints = new Vector3[Zombie.PathHolder.childCount];
        Zombie.GetComponent<Animator>().Play("Walking");

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = Zombie.PathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, Zombie.transform.position.y, waypoints[i].z);
        }

        Zombie.StartCoroutine(FollowPath(waypoints));

        IEnumerator FollowPath(Vector3[] waypointosu)
        {
            Zombie.transform.position = waypointosu[0];
            int TargetWaypointIndex = 1;
            Vector3 TargetWaypoint = waypointosu[TargetWaypointIndex];
            Zombie.transform.LookAt(TargetWaypoint);

            while (true)
            {
                Zombie.transform.position = Vector3.MoveTowards(Zombie.transform.position, TargetWaypoint, Zombie.Speed * Time.deltaTime);
                if (Zombie.transform.position == TargetWaypoint)
                {
                    TargetWaypointIndex = (TargetWaypointIndex + 1) % waypointosu.Length;
                    TargetWaypoint = waypointosu[TargetWaypointIndex];

                }
            }
        }*/
    }
}
