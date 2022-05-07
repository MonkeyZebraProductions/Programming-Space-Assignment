using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject NewExplosion;
    public float TriggerTime, CancelTime;

    private float i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        i += Time.deltaTime;
        if (i>=TriggerTime)
        {
            NewExplosion.SetActive(true);
        }
        //if (i >= CancelTime)
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
