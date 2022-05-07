using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayerAway : MonoBehaviour
{

    public Transform Player;

    public float MinDistance, CloseDistance;

    public float force,traction,CloseMultiplier;

    
    private Vector3 PushDirection;
    private Quaternion LookRot;
    private StabaliseShip _ss;
    // Start is called before the first frame update
    void Start()
    {
        _ss = FindObjectOfType<StabaliseShip>();
        Player = GameObject.Find("Arwing").transform;
    }

    // Update is called once per frame
    void Update()
    {
        PushDirection = (transform.position - Player.position).normalized;
        Vector3 Inverted = new Vector3(PushDirection.x, PushDirection.y, -PushDirection.z);
        if(Vector3.Distance(transform.position, Player.position) <= MinDistance)
        {
            _ss.IsStabalised = false;
            if(Vector3.Distance(transform.position, Player.position) <= CloseDistance)
            {
                force += traction*CloseMultiplier * Time.deltaTime;
            }
            else
            {
                force += traction * Time.deltaTime;
            }
            LookRot = Quaternion.LookRotation(-PushDirection, Vector3.up);
        }
        else
        {
            
            force -= traction * Time.deltaTime;
            if (force <= 0)
            {
                force = 0;
                _ss.IsStabalised = true;
            }
            LookRot = Quaternion.LookRotation(Inverted, Vector3.up);
        }
        
        Player.position -= PushDirection * force;


        Player.rotation = Quaternion.Lerp(Player.rotation, LookRot, traction / 5f);
    }
}
