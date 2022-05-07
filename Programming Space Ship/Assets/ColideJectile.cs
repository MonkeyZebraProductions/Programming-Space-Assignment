using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColideJectile : MonoBehaviour
{
    public Animator FoxAnimator;
    public AudioSource Darnit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        FoxAnimator.Play("Open");
        Darnit.Play();
    }
}
