using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Vector3> waypoints;
    public bool IsLooped;
    public float distance;
    public float approachDistance;
    private int i = 1;

    private void Awake()
    {
        waypoints[0] = transform.position;
        foreach( Transform child in transform)
        {
            waypoints[i] = child.position;
            i++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        foreach(Vector3 point in waypoints)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(point, 1);
        }
        
    }
}
