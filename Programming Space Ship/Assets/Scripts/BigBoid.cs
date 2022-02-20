using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoid : MonoBehaviour
{
    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 force;
    public float speed, banking;
    public float bankRatio=0.01f;
    public float mass = 1;
    public float maxSpeed = 10;
    public float approachModifier=2;

    private Path path;
    private int index;

    public bool seekEnabled = true; 
    public Transform seekTarget;

    //If the boid is Following
    public bool IsFollowPath;
    public float FollowSpeed = 10;
    public Transform PathTarget;

    //If the boid is Persuing
    public bool IsPersuing;
    public float PersueSpeed = 20;
    public Transform PersueTarget;

    public Transform ModelCollision;

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
        seekTarget = PathTarget;
        maxSpeed = FollowSpeed;
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

    void Persue()
    {
        seekTarget = PersueTarget;
        maxSpeed = PersueSpeed;
    }

    //Calculates rotation around Z axis
    float BankValue()
    {
        Vector3 targetDir = seekTarget.position-transform.position;
        banking = Mathf.Abs(Vector3.SignedAngle(targetDir, transform.position, Vector3.forward)*bankRatio);
        return banking;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFollowPath)
        {
            IsPersuing = false;
            FollowPath();
            Approach();
        }
        
        if(IsPersuing)
        {
            IsFollowPath = false;
            Persue();
        }
        force = Calculate();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        speed = velocity.magnitude;

        Debug.Log(BankValue());

        if (speed > 0)
        {

            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * BankValue()), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);
        }

    }
}
