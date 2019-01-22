using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject MissleType;
    
    public float RocketSpawnSpeed = 5f;
    public int MaxRocketCount = 10;
    private int CurrentRocketCount = 0;

    private float LastSpawn;


    // Start is called before the first frame update
    void Start()
    {
       LastSpawn  = Time.time;
        FireRocket();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastSpawn >= RocketSpawnSpeed)
        {
            FireRocket();
            LastSpawn = Time.time;
        }
    }


    void FireRocket()
    {
        Instantiate(MissleType, transform.position, transform.rotation);
    }
}
