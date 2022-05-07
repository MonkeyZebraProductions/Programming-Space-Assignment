using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{

    public Transform leader;
    public float lerpValue; //Change this to make formation travel more or less chaotic
    private Vector3 OffsetVector;

    // Start is called before the first frame update
    public void Start()
    {
        OffsetVector = transform.position - leader.position;
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position =Vector3.Lerp(transform.position,leader.TransformPoint(OffsetVector),lerpValue);
        //transform.rotation = Quaternion.Lerp(transform.rotation,leader.rotation,lerpValue);
    }
}
