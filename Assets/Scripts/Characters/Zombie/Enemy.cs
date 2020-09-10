using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // This variable is used so that the zombie shall know where it's supposed to go to. 
    // The "Transform" type of variable is one that holds info for the transform components of the object it references. 
    public float Speed = 2.5f;
    public float WaitingTime = 25;
    // The TurnSpeed is supposed to be the DegreesPerSecond value, so, that's 90 DegreesPerSecond.
    public float TurnSpeed = 180;

    public Transform PathHolder;
    public GameObject Zombie;
    public bool Walking = false;

    //public Light Spotlight;
    public GameObject View;
    public float ViewDistance;
    public LayerMask ViewMask;
    //float ViewAngle;

    Transform Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        // The spolight's angle shall be used as the angle of vision of the enemy, but the
        // light itself won't be used, because that would be really dumb. 
        

        Vector3[] waypoints = new Vector3[PathHolder.childCount];

        // A loop that gets the PathHolder's waypoints' positions and stores them in a variable, the "waypoints"
        // Vector3 variable declared above.
        for (int i = 0; i < waypoints.Length; i++) 
        {
            waypoints [i] = PathHolder.GetChild (i).position;

            // This line is used to make sure that the waypoints will stay at the same height as the enemy.
            waypoints [i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        // This is the equivalent to calling a method on other programming languages.
        StartCoroutine (FollowPath(waypoints));
    }

    /*bool CanSeePlayer() 
    {
        if (Vector3.Distance(transform.position, Player.position) < ViewDistance)
        {
            Vector3 DirToPlayer = (Player.position - transform.position).normalized;
            float AngleBetweenEnemyAndPlayer = Vector3.Angle (transform.forward, DirToPlayer);
            if (AngleBetweenEnemyAndPlayer < ViewAngle/2f)
            {
                if (!Physics.Linecast (transform.position, Player.position, ViewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }*/

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints [0];
        int TargetWaypointIndex = 1;
        Vector3 TargetWaypoint = waypoints [TargetWaypointIndex];
        transform.LookAt (TargetWaypoint);
        
        while (true)
        {
            Walking = true;
            transform.position = Vector3.MoveTowards (transform.position, TargetWaypoint, Speed * Time.deltaTime);
            if (transform.position == TargetWaypoint) 
            {
                TargetWaypointIndex = (TargetWaypointIndex + 1) % waypoints.Length;
                TargetWaypoint = waypoints [TargetWaypointIndex];
                Walking = false;
                Zombie.GetComponent<Animator>().Play("Idle");
                yield return new WaitForSeconds (WaitingTime);
                yield return StartCoroutine (TurnToFace (TargetWaypoint));
            // This whole if statement means: if the enemy reaches one of its waypoints, its current target waypoint 
            // will be updated to the next one and the enemy will wait for some seconds before moving on.
            }
            yield return null;
        }
    }

    IEnumerator TurnToFace(Vector3 LookTarget) 
    {
        Vector3 DirToLookTarget = (LookTarget - transform.position).normalized;
        float TargetAngle = 90 - Mathf.Atan2 (DirToLookTarget.z, DirToLookTarget.x) * Mathf.Rad2Deg;
                
        while(Mathf.Abs (Mathf.DeltaAngle (transform.eulerAngles.y, TargetAngle)) > .05)
        {
            Walking = true;
            float Angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, TargetAngle, TurnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * Angle;
            yield return null;
        }
    }

    // A function utilised to put Gizmos (icons) in the shape of spheres on each of the "PathPoints"
    // in the enemy's path, making it easier to create the path itself.
    void OnDrawGizmos()
    {
        // "StartPosition" is a Vector3 that takes the first child of the PathHolder's position (x, y, z).
        Vector3 StartPosition = PathHolder.GetChild (0).position;
        Vector3 PreviousPosition = StartPosition;

        foreach (Transform waypoint in PathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, 1f);
            Gizmos.DrawLine(PreviousPosition, waypoint.position);
            PreviousPosition = waypoint.position;
        }
        // This makes the last position connect to the first one.
        Gizmos.DrawLine(PreviousPosition, StartPosition);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay (transform.position, transform.forward * ViewDistance);
    }

    void Update()
    {
        if (Walking == true)
        {
            Zombie.GetComponent<Animator>().Play("Walking");
        }
        else
        {
            Zombie.GetComponent<Animator>().Play("Idle");
        }

        /*if (CanSeePlayer ())
        {
            Debug.Log("The player is being seen by the enemy!");
        }*/
        /*(else
        {
            Debug.Log("The player isn't being seen by the enemy anymore!");
        }*/

    }

}
