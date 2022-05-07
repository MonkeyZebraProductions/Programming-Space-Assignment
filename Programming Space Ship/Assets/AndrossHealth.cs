using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndrossHealth : MonoBehaviour
{
    public float Health, BulletDamage;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<=0)
        {
            SceneManager.LoadScene(index);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Bullet")
        {
            Health -= BulletDamage;
        }
    }
}
