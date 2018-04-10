using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyFollow : MonoBehaviour
{

	// Makes enemies follow the player
	int MoveSpeed = 1;
	int MaxDist = 10;
	int attackDist = 3;
	int MinDist = 2;
	float lastHitTime = 0;

	void Start()
	{
		
	}

	void Update(){
		if (Player.instance != null && Vector3.Distance (transform.position, Player.instance.transform.position) <= MaxDist) {

			transform.LookAt (Player.instance.transform);

			if (Vector3.Distance (transform.position, Player.instance.transform.position) >= MinDist) {
				transform.position += transform.forward * MoveSpeed * Time.deltaTime;
			}

			if (Vector3.Distance (transform.position, Player.instance.transform.position) <= attackDist && Time.time >= lastHitTime + 3) {
				// Call enemy attack instead of die
				Player.instance.Injure ();
				lastHitTime = Time.time;
			}

		}
	}
}