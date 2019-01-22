using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

	private Transform target;

	public float speedMin = 5f;
    public float speedMax = 10f;

    private float speed;

	public float rotateSpeed = 200f;

    public GameObject HitPlayerEffect;
    public GameObject HitMissleEffect;
    public GameObject EngineExplodeEffect;

    private float SpawnTime;
    private float MaxLifeSpan;
    
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        speed = Random.Range(speedMin, speedMax);
        MaxLifeSpan = Random.Range(5f, 15f);
        SpawnTime = Time.time;
	}

    
    void Update()
    {
        if (Time.time - SpawnTime > MaxLifeSpan)
        {
            Explode(EngineExplodeEffect);
        }
    }

    void FixedUpdate () {
		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D (Collider2D target)
	{
        if (target.tag == "Player")
        {
            Explode(HitPlayerEffect);
        }
        else if (target.tag == "Missile")
        {
            Explode(HitMissleEffect);
        }
	}


    void Explode(GameObject explosionType)
    {
        Instantiate(explosionType, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
