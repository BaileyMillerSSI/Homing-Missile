using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    public float maxHeight = 10f;
	public float speed = 1f;


	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		transform.Translate(horizontal, vertical, 0f);

        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
	}
}
