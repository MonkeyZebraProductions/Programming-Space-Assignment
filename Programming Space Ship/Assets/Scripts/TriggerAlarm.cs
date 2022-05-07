using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAlarm : MonoBehaviour
{
    private AudioSource Alarm;
    private MeshRenderer _mr;
    public GameObject Peppy;
    // Start is called before the first frame update
    void Start()
    {
        _mr = GetComponent<MeshRenderer>();
        Alarm = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Alarm.Play();
        _mr.material.color = Color.red;
        Peppy.SetActive(true);
    }
}
