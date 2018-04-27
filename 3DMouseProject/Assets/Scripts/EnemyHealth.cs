using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	int health = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// FIGURE  SHIT OUT
	void OnCollisionEnter(Collision shit){
		if (shit.collider.GetComponent<Poop>()){
			health--;
		}

		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
	
