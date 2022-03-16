using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayerAway : MonoBehaviour
{

    public Transform Player;

    public float MinDistance, CloseDistance;

    public float force,traction;

    
    private Vector3 PushDirection;
    private Quaternion LookRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PushDirection = (transform.position - Player.position).normalized;
        if(Vector3.Distance(transform.position, Player.position) <= MinDistance)
        {
            force += traction * Time.deltaTime;
            LookRot = Quaternion.LookRotation(-PushDirection, Vector3.up);
        }
        else
        {
            force -= traction * Time.deltaTime;
            if (force < 0)
            {
                force = 0;
            }
            LookRot = Quaternion.Euler(0, 0, 0);
        }
        Player.position -= PushDirection * force;
        

        Player.rotation = Quaternion.Lerp(Player.rotation, LookRot, traction/10f);
    }
}
