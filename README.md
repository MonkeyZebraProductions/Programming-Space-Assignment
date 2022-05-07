# Programming-Space-Assignment
Name: Conor Mulgrew

Student Number: C19905292

Class Group: Game Engines 2, Game Design

# Project Description

For my project I recreated the final boss from Star Fox (1993) using Unity AI

![image](https://github.com/MonkeyZebraProductions/Programming-Space-Assignment/blob/main/Capture.PNG)

# Instructions

* To use my project launch the game from file

* The Sequence will play itself

[Here](https://youtu.be/v4SGN2-e45w) is my project running

# How It Works

Ship Movement
```
public class BetterBoid : MonoBehaviour
{

    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 force;
    public float speed, banking;
    public float bankRatio = 0.01f;
    public float mass = 1;
    public float maxSpeed = 10;
    public float approachModifier = 2;

    private Path path;
    private int index;

    public bool seekEnabled = true;
    public Transform seekTarget;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = (target - transform.position).normalized * maxSpeed;
        return desired - velocity;
    }

    Vector3 Calculate()
    {

        force = Vector3.zero;
        if (seekEnabled)
        {
            force += Seek(seekTarget.position);
        }
        return force;
    }

    // Update is called once per frame
    void Update()
    {
        force = Calculate();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        speed = velocity.magnitude;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Seek(seekTarget.position), Vector3.up), 0.01f);
    }
}
```
  
  Spawn Script to create projectiles
    
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
  
  How the ship avoids objects
  ```
  
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
```

How Scenes are moved between

```
public class SceneMover : MonoBehaviour
{
    public int index;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            
            SceneManager.LoadScene(index);
        }
    }
}
```

# References
   
  | Class | Source |
  | ----- | ----- |
  | AndrossHealth.cs | self written |
  | AndrossJectiles.cs | self written |
  | BetterBoid.cs | Modified from [source](https://github.com/skooter500/GE2-2021-2022/blob/master/GE2%202022/Assets/BigBoid.cs) |
  | BigBoid.cs | Taken from [source](https://github.com/skooter500/GE2-2021-2022/blob/master/GE2%202022/Assets/BigBoid.cs) |
  | CollideJectile.cs | self written |
  | Explosion.cs | self written |
  | Laser.cs | self written |
  | MoveCylander.cs | self written |
  | Offset.cs | self written |
  |PlaySoundsOverScenes.cs| Taken from [source](https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html) |
  | PushPlayerAway.cs | self written |
  | Path.cs |Modified from [source](https://github.com/skooter500/GE2-2021-2022/blob/master/GE2%202022/Assets/Path.cs) |
  | SceneMover.cs | self written |  
  | spin.cs | self written |
  | StabaliseShip.cs | self written |
  | TriggerAlarm.cs | self written |
 
  
  | Asset | Source |
  | ----- | ----- |
  | Main music | taken from [here](https://www.youtube.com/watch?v=-jbp2BZ3S9M) |
  | Victory music | taken from [here](https://www.youtube.com/watch?v=uFeHMVuUn2s) |
  | Arwing | taken from [here](https://skfb.ly/onyoP) |
  | Andross | taken from [here](https://skfb.ly/o86ow) |
  | SFX | taken from [here](https://www.101soundboards.com/boards/10698-star-fox-2-sounds) |
  | Skybox | taken from [here](https://assetstore.unity.com/packages/3d/environments/sci-fi/real-stars-skybox-lite-116333) |
  
  # What I am most proud of in this assignment
  
  The thing I am most proud of in this assignment the extra polish and music to make it feel authentic
  
  # Proposal
  
  For this project I will recreate the Star Fox final boss using unity AI.
  
  
