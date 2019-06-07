using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 3.5f;
	public float distanceToStop = 1f;
	public Vector3 direction;
	public Player player;
	public float eatingInterval = 0.5f;
	private float eatingTimer = 0f;
	public int damage = 3;
	public bool chasingPlayer = true;


	void Start () {
		
	}
	
	void Update () {
		if (Vector3.Distance(transform.position, player.transform.position) < distanceToStop) {
			chasingPlayer = false;

		}
		if (chasingPlayer) {
			transform.position += direction * speed * Time.deltaTime;
		} else {
			eatingTimer -= Time.deltaTime;
			if (eatingTimer <= 0f) {
				eatingTimer = eatingInterval;
				player.health -= damage;
			}
		}

	}
}
