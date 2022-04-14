using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabaliseShip : MonoBehaviour
{

    public float LerpValue,SlerpValue;
    public Transform ParentCenter;
    public bool IsStabalised;

    private Quaternion LookRot;
    // Update is called once per frame
    void Update()
    {
        if(IsStabalised)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, LerpValue);
            LookRot = Quaternion.LookRotation(ParentCenter.position, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, LookRot, SlerpValue);
        }
        
    }
}
