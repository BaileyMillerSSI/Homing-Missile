using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RepeatingGroundGenerator : MonoBehaviour
{
    public GameObject Player;

    public GameObject LeftWorld, RightWorld;
    private BoxCollider2D edgeLeft, edgeRight;

    // Start is called before the first frame update
    void Start()
    {
        edgeLeft = GetComponentsInChildren<BoxCollider2D>().Where(x=>x.offset.x == -15).First();
        edgeRight = GetComponentsInChildren<BoxCollider2D>().Where(x => x.offset.x == 15).First();
    }


    private void Update()
    {
        var distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance > 50 && transform.parent.gameObject.activeInHierarchy)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered " + collision.name);

        var heading = transform.position - collision.transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;


        if (direction.normalized.x < 0)
        {
            SpawnGround(Vector2.right, transform.parent.gameObject);
        }
        else if (direction.normalized.x > 0)
        {
            SpawnGround(Vector2.left, transform.parent.gameObject);
        }
    }


    public void SpawnGround(Vector2 direction, GameObject environment)
    {
        if (direction == Vector2.left)
        {
            if (LeftWorld == null)
            {
                LeftWorld = Instantiate(environment, new Vector3(transform.parent.position.x - 51, transform.parent.position.y, transform.position.z), transform.rotation, transform.parent.parent.transform);
                var rgg = LeftWorld.GetComponentInChildren<RepeatingGroundGenerator>();
                rgg.RightWorld = transform.parent.gameObject;
                
            }
            else if (LeftWorld != null)
            {
                LeftWorld.SetActive(true);
            }
            
        }
        else if (direction == Vector2.right)
        {
            if (RightWorld == null)
            {
                RightWorld = Instantiate(environment, new Vector3(transform.parent.position.x + 51, transform.parent.position.y, transform.position.z), transform.rotation, transform.parent.parent.transform);
                var rgg = RightWorld.GetComponentInChildren<RepeatingGroundGenerator>();
                rgg.LeftWorld = transform.parent.gameObject;
            }
            else if (RightWorld != null)
            {
                RightWorld.SetActive(true);
            }
            
        }
    }
}



