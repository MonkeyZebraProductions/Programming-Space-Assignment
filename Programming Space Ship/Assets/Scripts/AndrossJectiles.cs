using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrossJectiles : MonoBehaviour
{
    public float Speed,MinX,MaxX,MinY,MaxY,RotationSpeed,DestroyTime;

    private Vector3 RandomDir;
    private Quaternion rotator;
    // Start is called before the first frame update
    void Start()
    {
        RandomDir = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), 1).normalized;
        rotator = Quaternion.Euler(Random.Range(-RotationSpeed, RotationSpeed), Random.Range(-RotationSpeed, RotationSpeed), Random.Range(-RotationSpeed, RotationSpeed));
        Destroy(this.gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += RandomDir*Time.deltaTime*Speed;
        transform.rotation *= rotator;
    }
}
