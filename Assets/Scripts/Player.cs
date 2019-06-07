using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health = 100;
	public GameObject bulletPrefab;
	private float shootingTimer;
	public float shootingCooldown = 0.1f;
	public float meleeCooldown = 0.5f;

	void Start () {
		
	}
	
	void Update () {
		shootingTimer -= Time.deltaTime;

		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown ("space")) {
			if (shootingTimer <= 0f) {
				shootingTimer = shootingCooldown;

				Collider[] colliders = Physics.OverlapSphere (transform.position, 1f);
				bool meleeAttack = false;
				Enemy meleeEnemy = null;
				foreach (Collider collider in colliders) {
					if (collider.GetComponent<Enemy> () != null) {
						meleeAttack = true;
						meleeEnemy = collider.GetComponent<Enemy> ();
						break;
					}
				
				}

				if (meleeAttack == false) {
					GameObject bulletObject = Instantiate (bulletPrefab);
					bulletObject.transform.position = transform.position;

					Bullet bullet = bulletObject.GetComponent<Bullet> ();
					bullet.direction = Camera.main.transform.forward;

				} else {
					shootingTimer = meleeCooldown;
					Destroy (meleeEnemy.gameObject);
				}
			}
		}
	}
}
