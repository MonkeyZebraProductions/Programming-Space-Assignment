using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterBoid : MonoBehaviour
{

    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 force;
    public float speed, banking;
    public float bankRatio = 0.01f;
    public float mass = 1;
    public float maxSpeed = 10;
    public float approachModifier = 2;

    private Path path;
    private int index;

    public bool seekEnabled = true;
    public Transform seekTarget;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = (target - transform.position).normalized * maxSpeed;
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

    // Update is called once per frame
    void Update()
    {
        force = Calculate();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        speed = velocity.magnitude;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Seek(seekTarget.position), Vector3.up), 0.01f);
    }
}
