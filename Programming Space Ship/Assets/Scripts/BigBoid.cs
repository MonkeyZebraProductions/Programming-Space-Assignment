using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoid : MonoBehaviour
{
    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 force;
    public float speed;
    public float mass = 1;
    public float maxSpeed = 10;
    public float approachModifier=2;

    private Path path;
    private int index;

    public bool seekEnabled = true; 
    public Transform seekTarget;
    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<Path>();
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = (target - transform.position).normalized * maxSpeed/approachModifier;
        return desired - velocity;
    }

    Vector3 Calculate()
    {
       
        force = Vector3.zero;
        if (seekEnabled)
        {
            force += Seek(seekTarget.position);
        }
        return force;
    }

    void Approach()
    {
        if (Vector3.Distance(transform.position, seekTarget.position) <= path.approachDistance)
        { 
            approachModifier=5;
        }
        else
        {
            approachModifier = 1;
        }
    }

    void FollowPath()
    {
        
        if (Vector3.Distance(transform.position, seekTarget.position)<=path.distance)
        {
            index++;
            if (index > path.waypoints.Count - 1)
            {
                if (path.IsLooped)
                {
                    index = 0;
                }
            }
            seekTarget.position = path.waypoints[index];
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
        Approach();
        force = Calculate();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        speed = velocity.magnitude;

        if (speed > 0)
        {
            transform.forward = velocity;
        }

    }
}
