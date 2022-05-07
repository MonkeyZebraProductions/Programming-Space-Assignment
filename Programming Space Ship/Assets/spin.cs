using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float speed;
    private PlaySoundsOverScenes _Ps;
    // Start is called before the first frame update
    void Start()
    {
        _Ps = FindObjectOfType<PlaySoundsOverScenes>();
        _Ps.StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
