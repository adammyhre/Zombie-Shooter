using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 10f;
	public Vector3 direction;
	public float lifetime = 2f;


	void Start () {
		
	}
	
	void Update () {
		transform.position += speed * direction * Time.deltaTime;
		lifetime -= Time.deltaTime;
		if (lifetime <= 0)
			Destroy (gameObject);
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.GetComponent<Enemy>() != null) {
			Destroy (collider.gameObject);
			Destroy (this.gameObject);
		}
	}
}
