using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject SpawnObject;

    public float firerate;
    private float tick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tick += Time.deltaTime;
        if (tick >= firerate)
        {
            Instantiate(SpawnObject, transform.position, Quaternion.identity);
            tick = 0;
        }
    }
}
